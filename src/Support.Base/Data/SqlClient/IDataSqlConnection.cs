namespace Compori.Alphaplan.Plugin.Support.Data.SqlClient
{
    public interface IDataSqlConnection
    {
        /// <summary>
        /// Gets the SQL connection string.
        /// </summary>
        /// <value>The SQL connection string.</value>
        string SqlConnectionString { get; }

        /// <summary>
        /// Creates a new sql connection.
        /// </summary>
        /// <returns>SqlConnection.</returns>
        System.Data.SqlClient.SqlConnection Create();
    }
}
