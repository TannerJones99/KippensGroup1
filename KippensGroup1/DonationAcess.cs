using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KippensGroup1
{
    public class DonationAccess
    {
        private readonly MySqlConnection _conn;

        private string _connectionString = DBHandler.connectionStringBuilder("harry", "elbomonkey");
        public DonationAccess()
        {

            _conn = new MySqlConnection(_connectionString);
        }
        public IEnumerable<Donation> GetDept()
        {
            var sql = "SELECT * FROM donation";
            var result = this._conn.Query<Donation>(sql).ToList();
            return result;
        }

    }
}
