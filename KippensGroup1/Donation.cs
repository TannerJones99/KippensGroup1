using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KippensGroup1
{
    public class Donation
    {
        public string Name { get; set; }

        public string description { get; set; }

        public int userID { get; set; }

        public int donationID { get; set; }

        public DateTime time { get; set; }

        public int roleID { get; set; }

        public int QUANTITY { get; set; }
    }
}
