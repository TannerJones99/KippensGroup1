using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KippensGroup1
{
    public class GetReportModel : PageModel
    {
        public string Error2 { get; set; }

        public void OnGet()
        {
            Error2 = "Enter your username and password";
        }

        public IActionResult OnPostDate()
        {
            return Redirect("/Index");
        }
    }
}