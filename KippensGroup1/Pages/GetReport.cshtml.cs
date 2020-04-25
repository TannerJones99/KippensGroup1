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
        public DateTime DateInput { get; set; }

        public void OnPost()
        {
            System.Diagnostics.Debug.WriteLine(DateInput.Month);
        }

        public void OnGet()
        {
            
        }

    }
}