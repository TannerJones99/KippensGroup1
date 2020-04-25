using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KippensGroup1
{
    public static class CurrentLogged
    {
        private static string username;
        private static int userID;
        private static int roleID;
        private static bool loggedIn;

        public static void logout()
        {
            username = "";
            userID = 0;
            roleID = 0;
            loggedIn = false;
        }

        public static int getRole()
        {
            return roleID;
        }

        public static void login(string user, int userid, int roleid)
        {
            username = user;
            userID = userid;
            roleID = roleid;
            loggedIn = true;
        }

        public static bool isLoggedIn()
        {
            return loggedIn;
        }

        public static string getUsername()
        {
            return username;
        }

        public static string getPassword()
        {
            string[] splited;
            splited = getLoginInfo().Split(',');
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder(splited[0], splited[1]));
            splited = null;
            string query = "SELECT password FROM user WHERE userID='"+userID+"';";
            MySqlDataReader reader = db.performQuery(query);
            reader.Read();
            return reader.GetString("password");
        }

        private static string getLoginInfo()
        {
            string filename = "mysqlLogin.txt";
            string[] lines = System.IO.File.ReadAllLines(".\\Data files\\" + filename);
            string uid =""; string pwd ="";
            foreach (string line in lines)
           
            {
                if (line[0] == 'u')
                {
                   uid = line.Remove(0, 4);
                }
                else if (line[0] == 'p')
                {
                    pwd = line.Remove(0, 4);
                }
            }

            return uid + "," + pwd;
        }
    }
}
