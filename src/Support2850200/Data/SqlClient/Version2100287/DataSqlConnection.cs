namespace Compori.Alphaplan.Plugin.Support.Data.SqlClient.Version2100287
{
    public class DataSqlConnection : SqlClient.DataSqlConnection
    {
        /// <summary>
        /// Gets the Alphaplan Login API.
        /// </summary>
        /// <value>Alphaplan Login API.</value>
        private Base.ApServer.ILogin LoginApi { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSqlConnection"/> class.
        /// </summary>
        /// <param name="loginApi">Alphaplan Login API.</param>
        public DataSqlConnection(Base.ApServer.ILogin loginApi)
        {
            this.LoginApi = loginApi;
        }

        /// <summary>
        /// Gets the SQL connection string.
        /// </summary>
        /// <value>The SQL connection string.</value>
        protected override string SqlConnectionString => this.LoginApi.ConnectionStringSql;
    }
}
