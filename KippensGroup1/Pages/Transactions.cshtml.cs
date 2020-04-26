using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace KippensGroup1.Pages
{
    public class TransactionsModel : PageModel
    {
        public string Error { get; set; }

        public void OnGet()
        {
            Error = "Fill out the info below";
        }

        public IActionResult OnPostDonation(string name, string description, string quantity)
        {
            int quantityValue;
            if (!int.TryParse(quantity, out quantityValue))
            {
                Error = "Quantity needs to be a number value";
                return Page();
            }
            if (name == null || description == null || quantityValue == null)
            {
                Error = "error, no fields can be left blank";
                return Page();
            }
            else
            {
                DBHandler db = new DBHandler(DBHandler.connectionStringBuilder(MysqlLogins.getMySqlUser(), MysqlLogins.getMySqlPass()));
                string query = "INSERT INTO transactions(name, description, userID, time, roleID, QUANTITY) VALUES ('" + name + "', '" + description + "', '" + CurrentLogged.getID() + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + CurrentLogged.getRole() + "', '" + quantityValue + "');";
                MySqlDataReader reader;

                try
                {
                    reader = db.performQuery(query);
                    if (reader == null)
                    {
                        Error = "can not perform query";
                        return Page();
                    }
                }
                catch (Exception e)
                {
                    Error = "Could not perform query";
                    return Page();
                }
            }


            return Redirect("Account");
        }
    }
}