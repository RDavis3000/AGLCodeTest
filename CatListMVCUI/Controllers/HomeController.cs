using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatListMVCUI.Models;
using PetOwnerService;

namespace CatListMVCUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly CatsAlphaOwnerGenderService catsAlphaOwnerGenderService;

        public HomeController(CatsAlphaOwnerGenderService catsAlphaOwnerGenderService)
        {
            this.catsAlphaOwnerGenderService = catsAlphaOwnerGenderService;
        }

        public async Task<IActionResult> CatList()
        {
            var viewModel = await catsAlphaOwnerGenderService.GetCatsAlphaOwnerGenderDictionaryAsync();

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
