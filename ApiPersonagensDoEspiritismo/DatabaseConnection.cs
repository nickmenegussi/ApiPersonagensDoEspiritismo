// Data/Database.cs
using System.Data;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ApiPersonagensDoEspiritismo.Data
{
    public class Database
    {
        private readonly string _connectionString;

        public Database()
        {
            // Suas credenciais do Clever Cloud
            _connectionString = "Server=bwjyvovmsptplzpxq1lz-mysql.services.clever-cloud.com;Port=3306;Database=bwjyvovmsptplzpxq1lz;User Id=uyzhzyevclxqwkvt;Password=ZVos9vNm0JxcNZoC89EH;";
        }

        public DataTable ExecuteQuery(string sql)
        {
            var table = new DataTable();
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            using var reader = command.ExecuteReader();
            table.Load(reader);
            return table;
        }

        public int ExecuteNonQuery(string sql)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            return command.ExecuteNonQuery();
        }

        public object ExecuteScalar(string sql)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            return command.ExecuteScalar();
        }
    }
}