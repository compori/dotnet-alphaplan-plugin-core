using System.Data.SqlClient;

namespace Compori.Alphaplan.Plugin.Support.Data.SqlClient
{
    public abstract class DataSqlConnection : IDataSqlConnection
    {
        /// <summary>
        /// Gets the SQL connection string.
        /// </summary>
        /// <value>The SQL connection string.</value>
        protected abstract string SqlConnectionString { get; }

        /// <summary>
        /// Creates a new sql connection.
        /// </summary>
        /// <returns>SqlConnection.</returns>
        private SqlConnection Create()
        {
            return new SqlConnection(this.SqlConnectionString);
        }

        /// <summary>
        /// Gets the SQL connection string.
        /// </summary>
        /// <value>The SQL connection string.</value>
        string IDataSqlConnection.SqlConnectionString => this.SqlConnectionString;

        /// <summary>
        /// Creates a new sql connection.
        /// </summary>
        /// <returns>SqlConnection.</returns>
        SqlConnection IDataSqlConnection.Create()
        {
            return this.Create();
        }
    }
}
