using ApServer;
using Base.ApServer;
using System;

namespace Compori.Alphaplan.Plugin.Support.Data.Version2100287
{
    public class WriterFactory : IWriterFactory
    {
        /// <summary>
        /// The sync threading object.
        /// </summary>
        private readonly object _thisLock = new object();

        /// <summary>
        /// Get the default writer implementation.
        /// </summary>
        /// <value>The default writer.</value>
        private IWriter DefaultWriter { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WriterFactory"/> class.
        /// </summary>
        /// <param name="defaultWriter">The default writer.</param>
        public WriterFactory(IWriter defaultWriter)
        {
            this.DefaultWriter = defaultWriter;
        }

        /// <summary>
        /// Creates the writer.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="user">The user.</param>
        /// <param name="handle">The handle.</param>
        /// <returns>Base.ApServer.IWriter.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private IWriter Create(string table, int user, out IntPtr handle)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(table, nameof(table));
            Guard.AssertArgumentIsInRange(user, nameof(user), v => v > 0);


            if (!((this.DefaultWriter as Writer)?.Manager is ManagerApServer manager))
            {
                throw new InvalidOperationException("Could not retrieve manager object from default writer.");
            }

            var dataWriter = "DataWriter";
            if (!(manager.NewInstance(ref dataWriter) is Writer writer))
            {
                throw new InvalidOperationException($"Could not create a writer to table '{table}'.");
            }
            try
            {
                handle = writer.CreateRSTI(ref table, user, true);
#if DEBUG
                // ReSharper disable once StringLiteralTypo
                System.Diagnostics.Debug.WriteLine($"IWriter.CreateRSTI('{table}',  '{user}') executed.");
#endif
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Access to table '{table}' could not be established.", ex);
            }

            return writer;
        }

        /// <summary>
        /// Closes the specified writer implementation.
        /// </summary>
        /// <param name="writer">The writer implementation.</param>
        private void Close(IWriter writer)
        {
            lock (_thisLock)
            {
                (writer as Writer)?.Beenden();
            }
        }

        /// <summary>
        /// Creates a writer object on a specific table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="user">The user.</param>
        /// <param name="handle">The handle.</param>
        /// <returns>IWriter.</returns>
        IWriter IWriterFactory.Create(string table, int user, out IntPtr handle)
        {
            lock (_thisLock)
            {
                return this.Create(table, user, out handle);
            }
        }

        /// <summary>
        /// Closes the specified writer implementation.
        /// </summary>
        /// <param name="writer">The writer implementation.</param>
        void IWriterFactory.Close(IWriter writer)
        {
            this.Close(writer);
        }
    }
}
