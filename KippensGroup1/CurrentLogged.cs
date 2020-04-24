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
    }
}
