using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public IActionResult OnPostReport()
        {
            if(CurrentLogged.getRole() != 2 || CurrentLogged.getRole() != 3)
            {
                Error = "You are not authorized to search for reports";
                return Page();
            }
            return Redirect("GetReport");
        }
    }
}