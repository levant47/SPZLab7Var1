using System.Data.SqlClient;

namespace SPZLab7Var1
{
    public static class DatabaseUtility
    {
        private const string _connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Database=SPZLab7Var1DB";

        public static SqlConnection GetSqlConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}

