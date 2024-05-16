using System;

namespace Compori.Alphaplan.Plugin.Support.Data
{
    public interface ITable : IDisposable
    {
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        string Name { get; }

        /// <summary>
        /// Gets the primary key field.
        /// </summary>
        /// <value>The identifier field.</value>
        string PrimaryKeyField { get; }

        /// <summary>
        /// Gets the identifier in primary key field.
        /// </summary>
        /// <value>The identifier.</value>
        long Id { get; }

        /// <summary>
        /// Gets the current filter.
        /// </summary>
        /// <value>The current filter.</value>
        string Filter { get; }

        /// <summary>
        /// Gets the current filter items.
        /// </summary>
        /// <value>The current filter.</value>
        string[] FilterList { get; }

        /// <summary>
        /// Clears the filter.
        /// </summary>
        ITable Clear();

        /// <summary>
        /// Sets the filter.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        ITable Where(string filter);

        /// <summary>
        /// Seeks to a record with the specified field value.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        ITable Where(string field, string value);

        /// <summary>
        /// Seeks to a record with the specified field value.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        ITable Where(string field, int value);

        /// <summary>
        /// Sets the filter with and to the current filter.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        ITable AndWhere(string filter);

        /// <summary>
        /// Sets the filter with and to the current filter.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        ITable AndWhere(string field, string value);

        /// <summary>
        /// Sets the filter with and to the current filter.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        ITable AndWhere(string field, int value);

        /// <summary>
        /// Seeks to a record withe the specified identifier as primary key.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ITable.</returns>
        ITable Seek(long id);

        /// <summary>
        /// Gets the value of the field from current record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">The field.</param>
        /// <returns>T.</returns>
        T Get<T>(string field);

        /// <summary>
        /// Sets the specified field in to record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns>ITable.</returns>
        ITable Set<T>(string field, T value);

        /// <summary>
        /// Creates a new data record.
        /// </summary>
        ITable Create();

        /// <summary>
        /// Updates the current data record.
        /// </summary>
        ITable Update();

        /// <summary>
        /// Deletes the current data record.
        /// </summary>
        ITable Delete();

        #region Move Operations

        /// <summary>
        /// Moves to the first record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        bool First();

        /// <summary>
        /// Moves to the last record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        bool Last();

        /// <summary>
        /// Moves to the next record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        bool Next();

        /// <summary>
        /// Moves to the previous record in current result set of that table.
        /// </summary>
        /// <returns><c>true</c> if move operation succeeds, <c>false</c> otherwise.</returns>
        bool Previous();

        #endregion
    }
}
