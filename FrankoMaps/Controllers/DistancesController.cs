using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repositories;
using FrankoMaps.Areas.Identity.Data;
using FrankoMaps.Models;
using FrankoMaps.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FrankoMaps.Controllers
{
    public class DistancesController : Controller
    {
        private readonly ILogger<DistancesController> _logger;
        private readonly DistancesService _distanceService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DistancesController(
            ILogger<DistancesController> logger,
            DistancesService distanceService,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _distanceService = distanceService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewBag.Distances = _distanceService.GetDistances();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_distanceService.GetDistance(id));
        }
        [HttpPost]
        public IActionResult Edit(DistanceViewModel distance)
        {
            _distanceService.UpdateDistance(distance, _userManager.GetUserId(User));

            return RedirectToAction("Index", "Distances");
        }
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}