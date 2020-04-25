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

        [BindProperty]
        public int DateType { get; set; }

        public void OnGet()
        {
         

        }

        public IActionResult OnPostSubmit()
        {
            
            return RedirectToPage("ShowReport", "page", new { start = StartDate, end = EndDate });
        }

    }
}