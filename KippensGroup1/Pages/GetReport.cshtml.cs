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
        //[BindProperty]
        public string ReportType { get; set; }

        public void OnPost()
        {

        }

        public void OnGet()
        {
            ReportType = "week";
        }

        public IActionResult OnPostDate()
        {
            return Page();
        }

    }
}