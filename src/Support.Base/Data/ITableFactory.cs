using System;

namespace Compori.Alphaplan.Plugin.Support.Data
{
    public interface ITableFactory : IDisposable
    {
        /// <summary>
        /// Creates a table object on a specified table name.
        /// </summary>
        /// <param name="table">The table name.</param>
        /// <returns>ITable.</returns>
        ITable Create(string table);

        /// <summary>
        /// Creates a table object on a specified table name and it's primary key field.
        /// </summary>
        /// <param name="table">The table name.</param>
        /// <param name="primaryKeyField">The primary key field.</param>
        /// <returns>ITable.</returns>
        ITable Create(string table, string primaryKeyField);

        /// <summary>
        /// Creates a table object on a specified table name and it's primary key field by using a specific user.
        /// </summary>
        /// <param name="table">The table name.</param>
        /// <param name="primaryKeyField">The primary key field.</param>
        /// <param name="user">The user.</param>
        /// <returns>ITable.</returns>
        ITable Create(string table, string primaryKeyField, int user);
    }
}
