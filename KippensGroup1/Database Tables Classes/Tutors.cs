using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KippensGroup1.Database_Tables_Classes
{
    public class Tutors
    {
        public int tutorID;
        public int userID;
        public string name;
        public string email;
        public string subject;

        public Tutors(int tID, int uID, string subject)
        {
            this.tutorID = tID;
            this.userID = uID;
            this.subject = subject;
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder(MysqlLogins.getMySqlUser(), MysqlLogins.getMySqlPass()));
            string query = "SELECT user.name, user.email FROM user INNER JOIN tutors ON user.userID=tutors.userID WHERE tutors.userID='" + uID + "';";
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

        public string getSubject()
        {
            return this.subject;
        }
    }
}
