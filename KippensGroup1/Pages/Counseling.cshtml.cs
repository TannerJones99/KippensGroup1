using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace KippensGroup1.Pages.Shared
{
    public class CounselingModel : PageModel
    {
        public List<Database_Tables_Classes.Counselers> counselers;
        public void OnGet()
        {
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder(MysqlLogins.getMySqlUser(), MysqlLogins.getMySqlPass()));
            string query = "SELECT * FROM counselors;";
            MySqlDataReader reader = db.performQuery(query);
            counselers = new List<Database_Tables_Classes.Counselers>();
            while (reader.Read())
            {                
                counselers.Add(new Database_Tables_Classes.Counselers(reader.GetInt32("counselorID"), reader.GetInt32("userID")));
            }
        }
    }
}