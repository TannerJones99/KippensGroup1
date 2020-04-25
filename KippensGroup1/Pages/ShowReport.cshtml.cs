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
            execSqlRead();
            
            
        }

        public void execSqlRead()
        {
            MySqlConnection db = new MySqlConnection(DBHandler.connectionStringBuilder("harry", "elbomonkey"));
            string query = "SELECT * FROM transactions";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();  //stop here
            try
            {
                while (myReader.Read())
                {
                    Console.WriteLine(myReader.GetString(0));
                }
            }
            finally
            {
                Console.WriteLine("Yolo");
                myReader.Close();
            }

            //return myReader;
        }

    }
}
