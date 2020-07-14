using System;

namespace Compori.Alphaplan.Plugin.Support.Data
{
#pragma warning disable CA2237 // Mark ISerializable types with serializable
#pragma warning disable CA1032 // Implement standard exception constructors
    public class TableException : Exception
#pragma warning restore CA1032 // Implement standard exception constructors
#pragma warning restore CA2237 // Mark ISerializable types with serializable
    {
        /// <summary>
        /// Gets the table.
        /// </summary>
        /// <value>The table.</value>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public string Table { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableException" /> class.
        /// </summary>
        /// <param name="table">The table.</param>
        public TableException(string table)
        {
            this.Table = table;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableException" /> class.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="message">The message.</param>
        public TableException(string table, string message) : base(message)
        {
            this.Table = table;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableException" /> class.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public TableException(string table, string message, Exception innerException) : base(message, innerException)
        {
            this.Table = table;
        }
    }
}
