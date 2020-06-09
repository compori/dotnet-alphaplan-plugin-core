using Base.ApServer;
using System;
using System.Collections.Generic;

namespace Compori.Alphaplan.Plugin.Support.Data
{
    public sealed class TableFactory : ITableFactory
    {

#if NET35
        /// <summary>
        /// Simple Tuple Class backport
        /// </summary>
        private class Tuple<T1, T2>
        {
            /// <summary>
            /// Gets or sets the item1.
            /// </summary>
            /// <value>The item1.</value>
            public T1 Item1 { get; }

            /// <summary>
            /// Gets or sets the item1.
            /// </summary>
            /// <value>The item1.</value>
            public T2 Item2 { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="Tuple{T1, T2}"/> class.
            /// </summary>
            /// <param name="item1">The item1.</param>
            /// <param name="item2">The item2.</param>
            public Tuple(T1 item1, T2 item2)
            {
                this.Item1 = item1;
                this.Item2 = item2;
            }
        }

#endif

        /// <summary>
        /// Get the writer factory.
        /// </summary>
        /// <value>The writer factory.</value>
        private IWriterFactory WriterFactory { get; }

        /// <summary>
        /// Gets the pool with released IWriter objects.
        /// </summary>
        /// <value>The released writer and handles.</value>
        private Dictionary<string, Queue<Tuple<IWriter, IntPtr>>> Released  { get; }

        /// <summary>
        /// Get the pool with currently used IWriter objects.
        /// </summary>
        /// <value>The currently used writer objects.</value>
        private Dictionary<IWriter, Tuple<string, IntPtr>> Reserved  { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableFactory" /> class.
        /// </summary>
        /// <param name="writerFactory">The writer factory.</param>
        public TableFactory(IWriterFactory writerFactory)
        {
            Guard.AssertArgumentIsNotNull(writerFactory, nameof(writerFactory));

            this.WriterFactory = writerFactory;
            this.Released = new Dictionary<string, Queue<Tuple<IWriter, IntPtr>>>();
            this.Reserved = new Dictionary<IWriter, Tuple<string, IntPtr>>();
        }

        /// <summary>
        /// Liefert den Schlüssel zum Pool.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="user">The user.</param>
        /// <returns>System.String.</returns>
        private string GetPoolKey(string table, int user)
        {
            Guard.AssertArgumentIsNotNullOrWhiteSpace(table, nameof(table));
            Guard.AssertArgumentIsInRange(user, nameof(user), v => v > 0);

            return $"{table}@{user}";
        }

        /// <summary>
        /// The sync threading object.
        /// </summary>
        private readonly object _thisLock = new object();

        /// <summary>
        /// Creates a new IWriter and reserved it for writing in to a specific table.
        /// </summary>
        /// <param name="table">The table that will be used for the writer.</param>
        /// <param name="user">The use Id.</param>
        /// <param name="handle">The handle.</param>
        /// <returns>Data.IWriter.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private IWriter Reserve(string table, int user, out IntPtr handle)
        {
            lock (_thisLock)
            {
                var key = this.GetPoolKey(table, user);

                IWriter writer;

                //
                // check if a writer object is available.
                //
                if (this.Released.ContainsKey(key) && this.Released[key].Count > 0)
                {
                    // yes - recycle object
                    var value = this.Released[key].Dequeue();
                    writer = value.Item1;
                    handle = value.Item2;
                }
                else
                {
                    // no - create a brand new IWriter
                    writer = this.WriterFactory.Create(table, user, out handle);
                }
              
                if (!writer.Open(true))
                {
                    throw new TableException(table,"The table could not be opened.");
                }

                // set writer as reserved
                this.Reserved.Add(writer, new Tuple<string, IntPtr>(key, handle));

                return writer;
            }
        }

        /// <summary>
        /// Releases Writer object, that must be create by that table factory.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public void Release(IWriter writer)
        {
            lock (_thisLock)
            {
                if (!this.Reserved.ContainsKey(writer))
                {
                    return;
                }

                var value = this.Reserved[writer];
                var key = value.Item1;
                var handle = value.Item2;

                this.Reserved.Remove(writer);

                if (!this.Released.ContainsKey(key))
                {
                    this.Released[key] = new Queue<Tuple<IWriter, IntPtr>>();
                }
                this.Released[key].Enqueue(new Tuple<IWriter, IntPtr>(writer, handle));
            }
        }

        /// <summary>
        /// Creates a table object on a specified table name and it's primary key field by using a specific user.
        /// </summary>
        /// <param name="table">The table name.</param>
        /// <param name="primaryKeyField">The primary key field.</param>
        /// <param name="user">The user.</param>
        /// <returns>ITable.</returns>
        private ITable Create(string table, string primaryKeyField, int user)
        {
            var writer = this.Reserve(table, user, out var handle);
            return new Table(this, writer, handle, table, primaryKeyField);
        }

        #region ITableFactory Implementation

        /// <summary>
        /// Creates a table object on a specified table name.
        /// </summary>
        /// <param name="table">The table name.</param>
        /// <returns>ITable.</returns>
        ITable ITableFactory.Create(string table)
        {
            Guard.AssertArgumentIsNotNull(table, nameof(table));

            return this.Create(table, table + "ID", 1);
        }

        /// <summary>
        /// Creates a table object on a specified table name and it's primary key field.
        /// </summary>
        /// <param name="table">The table name.</param>
        /// <param name="primaryKeyField">The primary key field.</param>
        /// <returns>ITable.</returns>
        ITable ITableFactory.Create(string table, string primaryKeyField)
        {
            return this.Create(table, primaryKeyField, 1);
        }

        /// <summary>
        /// Creates a table object on a specified table name and it's primary key field by using a specific user.
        /// </summary>
        /// <param name="table">The table name.</param>
        /// <param name="primaryKeyField">The primary key field.</param>
        /// <param name="user">The user.</param>
        /// <returns>ITable.</returns>
        ITable ITableFactory.Create(string table, string primaryKeyField, int user)
        {
            return this.Create(table, primaryKeyField, user);
        }
        #endregion

        #region IDisposable Support

        /// <summary>
        /// The disposed value
        /// </summary>
        private bool _disposedValue;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> 
        /// to release only unmanaged resources.</param>
        // ReSharper disable once UnusedParameter.Global
        // ReSharper disable once UnusedParameter.Local
#pragma warning disable IDE0060 // Nicht verwendete Parameter entfernen
        private void Dispose(bool disposing)
#pragma warning restore IDE0060 // Nicht verwendete Parameter entfernen
        {
            if (_disposedValue)
            {
                return;
            }

            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach(var queue in this.Released)
            {
                foreach(var item in queue.Value)
                {
                    this.WriterFactory.Close(item.Item1);
                }
            }

            this.Released.Clear();
            _disposedValue = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
#pragma warning disable CA1063 // Implement IDisposable Correctly
        void IDisposable.Dispose()
#pragma warning restore CA1063 // Implement IDisposable Correctly
        {
            Dispose(true);
        }

        #endregion
    }
}
