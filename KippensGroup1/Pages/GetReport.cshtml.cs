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
        public DateTime StartDate { get; set; }

        [BindProperty]
        public DateTime EndDate { get; set; }

        [BindProperty]
        public int DateType { get; set; }


        public void OnPost()
        {
            //System.Diagnostics.Debug.WriteLine(StartDate);
            //System.Diagnostics.Debug.WriteLine(EndDate);
            //RedirectToPage("ShowReport", StartDate);

        }

        public void OnGet()
        {


        }


        public IActionResult OnPostSubmit()
        {
            System.Diagnostics.Debug.WriteLine(StartDate);
            System.Diagnostics.Debug.WriteLine(EndDate);
            ShowReportModel srm = new ShowReportModel();
            return srm.Page();
        }

    }
}