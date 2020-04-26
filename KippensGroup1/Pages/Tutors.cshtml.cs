using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace KippensGroup1.Pages
{
    public class TutorsModel : PageModel
    {
        public List<Database_Tables_Classes.Tutors> tutors;
        public void OnGet()
        {
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder(MysqlLogins.getMySqlUser(), MysqlLogins.getMySqlPass()));
            string query = "SELECT * FROM tutors;";
            MySqlDataReader reader = db.performQuery(query);
            tutors = new List<Database_Tables_Classes.Tutors>();
            while (reader.Read())
            {
                tutors.Add(new Database_Tables_Classes.Tutors(reader.GetInt32("tutorID"), reader.GetInt32("userID"), reader.GetString("subject")));
            }
        }
    }
}