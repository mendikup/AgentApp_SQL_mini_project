using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DataBase
{
    public class DbConnectionFactory
    {
        private string ConnectionString;

        public DbConnectionFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public MySqlConnection GetOpenConnection()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
