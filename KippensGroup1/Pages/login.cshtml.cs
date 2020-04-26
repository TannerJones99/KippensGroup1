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

        public IActionResult OnGet()
        {
            if (CurrentLogged.isLoggedIn())
            {
                return Redirect("Account");
            }
            Error = "Enter your username and password";
            return null;
        }

        public IActionResult OnPostLogin(string user, string pass)
        {
            string query = "SELECT username, password, userID, roleID FROM user WHERE username='"+user+"' AND password='"+pass+"';";
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder(MysqlLogins.getMySqlUser(), MysqlLogins.getMySqlPass())); // change to username and password later
            MySqlDataReader reader;
            try
            {
                reader = db.performQuery(query);
                if(reader == null)
                {
                    Error = "Could not Query. reader is null";
                    
                    return Page();
                }
                else if (!reader.HasRows)
                {
                    Error = "Could not Login. Bad username or password";
                    
                    return Page();
                }
                else
                {
                    reader.Read();
                    CurrentLogged.login(reader.GetString("username"), reader.GetInt32("userID"), reader.GetInt32("roleID"));
                    return Redirect("Index");
                }
            }   
            catch (Exception e)
            {
                Error = "Error Querying Database"+db.getError();
                return Page();
            }
            
                               
        }

        public IActionResult OnPostSignup()
        {
            Error = "test";
            return Redirect("Signup");
        }
    }
}