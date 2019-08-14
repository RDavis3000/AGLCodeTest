using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetOwnerModels;

namespace CatListRazorUI.Pages
{
    public class IndexModel : PageModel
    {

        public Dictionary<string,Pet> CatList { get; set; }

        public void OnGet()
        {
            var 
        }
    }
}
