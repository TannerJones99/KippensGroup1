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
        [BindProperty]
        public string Number { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostDate()
        {
            return Redirect("./Login");
        }
    }
}