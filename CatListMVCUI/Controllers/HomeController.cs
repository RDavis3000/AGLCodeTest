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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CatList()
        {
            var viewModel = catsAlphaOwnerGenderService.GetCatsAlphaOwnerGenderDictionary().Result;

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
