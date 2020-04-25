using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KippensGroup1.Database_Tables_Classes
{
    public class User
    {
        public int userID { get; set; }

        public string name { get; set; }

        public string username { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public int number { get; set; }

        public int roleID { get; set; }
    }
}
