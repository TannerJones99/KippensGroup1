using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KippensGroup1
{
    public static class MysqlLogins
    {
        public static string getMySqlUser()
        {
            string filename = "mysqlLogin.txt";
            string[] lines = System.IO.File.ReadAllLines(".\\Data files\\" + filename);
            string user = "";
            foreach (string line in lines)
            {
                if (line[0] == 'u')
                {
                    user = line.Remove(0, 4);
                }
            }
            return user;
        }

        public static string getMySqlPass()
        {
            string filename = "mysqlLogin.txt";
            string[] lines = System.IO.File.ReadAllLines(".\\Data files\\" + filename);
            string pass = "";
            foreach (string line in lines)
            {
                if (line[0] == 'p')
                {
                    pass = line.Remove(0, 4);
                }
            }
            return pass;
        }

    }
}
