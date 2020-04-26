using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KippensGroup1.Database_Tables_Classes
{
    public class Counselers
    {
        public int counselerID;
        public int userID;
        public string name;
        public string email;

        public Counselers(int cID, int uID)
        {
            this.counselerID = cID;
            this.userID = uID;
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder(MysqlLogins.getMySqlUser(), MysqlLogins.getMySqlPass()));
            string query = "SELECT user.name, user.email FROM user INNER JOIN counselors ON user.userID=counselors.userID WHERE counselors.userID='" + uID + "';";
            MySqlDataReader reader = db.performQuery(query);
            reader.Read();
            name = reader.GetString("name");
            email = reader.GetString("email");
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getName()
        {
            return this.name;
        }
    }
}
