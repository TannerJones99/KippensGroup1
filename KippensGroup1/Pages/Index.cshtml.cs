using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KippensGroup1.Pages
{
    public class IndexModel : PageModel
    {
        public string logged { get; set; }
        public void OnGet()
        {
            logged = CurrentLogged.isLoggedIn().ToString();
        }
    }
}
