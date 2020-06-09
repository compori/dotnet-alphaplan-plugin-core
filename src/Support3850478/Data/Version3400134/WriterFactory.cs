using Base;
using Base.ApServer;
using System;

namespace Compori.Alphaplan.Plugin.Support.Data.Version3400134
{
    public class WriterFactory : IWriterFactory
    {
        /// <summary>
        /// The sync threading object.
        /// </summary>
        private readonly object _thisLock = new object();

        /// <summary>
        /// Get the manager implementation.
        /// </summary>
        /// <value>The manager implementation.</value>
        private IManagerBase Manager { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WriterFactory"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public WriterFactory(IManagerBase manager)
        {
            this.Manager = manager;
        }

        /// <summary>
        /// Creates the writer.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="user">The user.</param>
        /// <param name="handle">The handle.</param>
        /// <returns>Base.ApServer.IWriter.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private IWriter CreateWriter(string table, int user, out IntPtr handle)
        {
            var writer = (IWriter)this.Manager.ManagedObject(Names.Writer, false, true);
            writer.Start();

            try
            {
                handle = writer.CreateRSTI(ref table, user, true);
#if DEBUG
                // ReSharper disable once StringLiteralTypo
                System.Diagnostics.Debug.WriteLine($"IWriter.CreateRSTI('{table}', {user}) executed.");
#endif
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Access to table '{table}' could not be established.", ex);
            }

            return writer;
        }

        /// <summary>
        /// Creates a new writer implementation on a specific table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="user">The user.</param>
        /// <param name="handle">The handle.</param>
        /// <returns>IWriter.</returns>
        IWriter IWriterFactory.Create(string table, int user, out IntPtr handle)
        {
            lock (_thisLock)
            {
                return this.CreateWriter(table, user, out handle);
            }
        }

        /// <summary>
        /// Disposes the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        void IWriterFactory.Close(IWriter writer)
        {
            lock (_thisLock)
            {
                writer.Dispose();
            }
        }
    }
}
