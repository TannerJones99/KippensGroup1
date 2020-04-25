using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KippensGroup1.Database_Tables_Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KippensGroup1
{
    public class GetReportModel : PageModel
    {
        [BindProperty]
        public string StartDate { get; set; }

        [BindProperty]
        public string EndDate { get; set; }


        public void OnGet()
        {
         

        }

        // when user clicks submit button it redirects to ShowReport pages passing startDate and endDate
        public IActionResult OnPostSubmit()
        { 
            return RedirectToPage("ShowReport", "page", new { start = StartDate, end = EndDate });
        }

    }
}