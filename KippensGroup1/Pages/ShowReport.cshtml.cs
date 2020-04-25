using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KippensGroup1.Database_Tables_Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace KippensGroup1
{
    public class ShowReportModel : PageModel
    {
        public List<Donation> Donations { get; set; } // List of all records in donation table

        public List<User> Users { get; set; } // List of all records in user table

        public void OnGet()
        {
            var donAccess = new DatabaseAccess();
            Donations = donAccess.GetDonations();
            Users = donAccess.GetUsers();
            
        }

    }
}
