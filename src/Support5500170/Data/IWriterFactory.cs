using Base.ApServer;
using System;

namespace Compori.Alphaplan.Plugin.Support.Data
{
    public interface IWriterFactory
    {
        /// <summary>
        /// Creates a new writer implementation on a specific table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="user">The user.</param>
        /// <param name="handle">The handle.</param>
        /// <returns>IWriter.</returns>
        IWriter Create(string table, int user, out IntPtr handle);

        /// <summary>
        /// Closes the specified writer implementation.
        /// </summary>
        /// <param name="writer">The writer implementation.</param>
        void Close(IWriter writer);
    }
}
