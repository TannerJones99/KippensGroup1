using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace KippensGroup1.Pages
{
    public class loginModel : PageModel
    {
        public string Error { get; set; }

        public void OnGet()
        {
            Error = "Enter your username and password";
        }

        public IActionResult OnPostLogin(string user, string pass)
        {
            string query = "SELECT username, password FROM user WHERE username='" + user + "'AND password='" + pass + "';";
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder("harry", "elbomonkey")); // change to username and password later
            MySqlDataReader reader;
            try
            {
                reader = db.performQuery(query);
                if (!reader.HasRows)
                {
                    Error = "Could not Login. Bad username or password";
                    return Page();
                }
                else
                {
                    CurrentLogged.login(reader.GetString("username"), reader.GetInt32("userID"), reader.GetInt32("roleID"));
                    return Redirect("/Index");
                }
            }
            catch (Exception e)
            {
                Error = "Error Querying Database";
                return Page();
            }
                     
        }

        public IActionResult onPostSignUp()
        {
            return Redirect("/Signup");
        }
    }
}