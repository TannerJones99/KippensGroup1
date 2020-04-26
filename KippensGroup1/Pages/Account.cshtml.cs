using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace KippensGroup1.Pages
{
    public class AccountModel : PageModel
    {
        public string username { get; set; }
        public string Error { get; set; }

        public IActionResult OnGet()
        {
            if (!CurrentLogged.isLoggedIn())
            {
                return Redirect("Login");
            }
            username = CurrentLogged.getUsername();
            Error = "Select an option below";

            return Page();
        }

        public IActionResult OnPostLogout()
        {
            CurrentLogged.logout();
            return Redirect("Index");
        }

        public IActionResult OnPostDonation()
        {
            username = CurrentLogged.getUsername();
            if (CurrentLogged.getRole() != 2 && CurrentLogged.getRole() != 3)
            {
                Error = "You are not authorized to fill out a donation";
                return Page();
            }
            return Redirect("Donation");
        }

        public IActionResult OnPostTransaction()
        {
            username = CurrentLogged.getUsername();
            if (CurrentLogged.getRole() != 2 && CurrentLogged.getRole() != 3)
            {
                Error = "You are not authorized to fill out a transaction";
                return Page();
            }
            return Redirect("Transactions");
        }

        public IActionResult OnPostReport()
        {
            username = CurrentLogged.getUsername();
            System.Diagnostics.Debug.WriteLine(CurrentLogged.getRole());
            if (CurrentLogged.getRole() != 2 && CurrentLogged.getRole() != 3)
            {
                Error = "You are not authorized to search for reports";
                return Page();
            }
            return Redirect("GetReport");
        }

        public IActionResult OnPostPromote(string user)
        {
            if (CurrentLogged.getRole() == 1)
            {
                Error = "You are not authorized to promote users";
                return Page();
            }
            DBHandler db = new DBHandler(DBHandler.connectionStringBuilder(MysqlLogins.getMySqlUser(), MysqlLogins.getMySqlPass()));
            string query = "SELECT username FROM user WHERE username='" + user + "';";
            MySqlDataReader reader = db.performQuery(query);
            Error = "Unknown error occured";
            if (!reader.HasRows)
            {
                Error = "No user found";
            }
            else
            {
                query = "UPDATE user SET roleID = '" + CurrentLogged.getRole() + "' WHERE username='" + user + "';";
                reader = db.performQuery(query);
                Error = "Update successful";
            }
            
            username= CurrentLogged.getUsername();
            return Page();
        }
    }
}