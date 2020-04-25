using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace KippensGroup1
{
    public class ShowReportModel : PageModel
    {
        public string Description { get; set; }

        public void OnGet()
        {
            GetDataFromDB();
        }

        public void GetDataFromDB()
        {
            string query = "SELECT * FROM donation";
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder("harry", "elbomonkey")); // change to username and password later
            MySqlDataReader reader;
            try
            {
                reader = db.performQuery(query);

                Description = reader.GetString("description");

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error: Connection to database");
            }
        }

    }
}
