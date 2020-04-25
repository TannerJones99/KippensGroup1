using Dapper;
using KippensGroup1.Database_Tables_Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KippensGroup1
{
    public class DatabaseAccess
    {
        private readonly MySqlConnection _conn;

        private string _connectionString = DBHandler.connectionStringBuilder("harry", "elbomonkey");
        public DatabaseAccess()
        {

            _conn = new MySqlConnection(_connectionString);
        }

        public List<Donation> GetDonations(string start, string end)
        {
            var sql = "SELECT * FROM donation WHERE time BETWEEN '" + start + "' AND '"+ end + "' ORDER BY time;";
            var result = this._conn.Query<Donation>(sql).ToList();
            return result;
        }

        public List<Transaction> GetTransactions(string start, string end)
        {
            var sql = "SELECT * FROM transactions WHERE time BETWEEN '" + start + "' AND '" + end + "' ORDER BY time;";
            var result = this._conn.Query<Transaction>(sql).ToList();
            return result;
        }

        public List<User> GetUsers()
        {
            var sql = "SELECT * FROM user";
            var result = this._conn.Query<User>(sql).ToList();
            return result;
        }

    }
}
