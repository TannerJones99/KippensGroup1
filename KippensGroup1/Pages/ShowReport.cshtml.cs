﻿using System;
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
        public List<Donation> Donations { get; set; }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            var donAccess = new DatabaseAccess();
            Donations = donAccess.GetDonations();
            
            
        }

        public void GetDataFromDB()
        {
            Donation don = new Donation();
            string query = "SELECT * FROM donation";
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder("harry", "elbomonkey")); // change to username and password later
            MySqlDataReader reader;
            try
            {
                reader = db.performQuery(query);

                if (reader == null )
                {
                    System.Diagnostics.Debug.WriteLine("Could not Query. reader is null");
                }
                else if (!reader.HasRows) {

                    System.Diagnostics.Debug.WriteLine("Error: Somethig else");
                }
                else
                {
                    while (reader.Read())
                    {
                        //don.Name = reader.GetValue("Name");
                    }
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error: Connection to database");
            }
        }

    }
}
