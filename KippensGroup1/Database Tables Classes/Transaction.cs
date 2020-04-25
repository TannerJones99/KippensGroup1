using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KippensGroup1.Database_Tables_Classes
{
    public class Transaction
    {
        public int transactionID { get; set; }

        public DateTime time { get; set; }

        public int roleID { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int userID { get; set; }

        public int QUANTITY { get; set; }
    }
}
