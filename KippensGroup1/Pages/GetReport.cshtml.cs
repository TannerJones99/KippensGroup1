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
        public DateTime Date { get; set; }

        public void OnPost()
        {

        }

        public void OnGet()
        {
            //ReportType = "week";
        }

        public IActionResult OnPostDate()
        {
            return Page();
        }

    }
}