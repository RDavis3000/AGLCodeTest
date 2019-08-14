using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatListMVCUI.Models;
using PetOwnerService;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace CatListMVCUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly GetCatMapService _getCatMapService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(GetCatMapService catsAlphaOwnerGenderService, ILogger<HomeController> logger)
        {
            _getCatMapService = catsAlphaOwnerGenderService;
            _logger = logger;
        }

        public async Task<IActionResult> CatList()
        {
            try
            {
                //var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier);
                _logger.LogInformation($"HomeController.CatList called");// by {currentUserId.Value}");
                var viewModel = await _getCatMapService.GetCatMapAsync();
                _logger.LogInformation("HomeController.CatList retrieved viewModel");
                return View(viewModel);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Unhandled Exception in HomeController.CatList");
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
