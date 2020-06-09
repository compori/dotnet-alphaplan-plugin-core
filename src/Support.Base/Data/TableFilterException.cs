using System;

namespace Compori.Alphaplan.Plugin.Support.Data
{
#pragma warning disable CA2237 // Mark ISerializable types with serializable
    public class TableFilterException: TableException 
#pragma warning restore CA2237 // Mark ISerializable types with serializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableFilterException"/> class.
        /// </summary>
        /// <param name="table">The table.</param>
        public TableFilterException(string table) : base(table)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableFilterException"/> class.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="message">The message.</param>
        public TableFilterException(string table, string message) : base(table, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableFilterException"/> class.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public TableFilterException(string table, string message, Exception innerException) : base(table, message, innerException)
        {
        }
    }
}
