using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrankoMaps.Models;
using FrankoMaps.Services;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using FrankoMaps.Areas.Identity.Data;
using System;

namespace FrankoMaps.Controllers
{
    public class MapsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PointsService _pointsService;
        private readonly DistancesService _distanceService;
        private readonly MapsService _mapService;
        private readonly UserManager<ApplicationUser> _userManager;
        private int X = -1;
        private int Y = -1;

        public MapsController(
            ILogger<HomeController> logger,
            PointsService pointsService,
            DistancesService distanceService,
            MapsService mapService,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _pointsService = pointsService;
            _distanceService = distanceService;
            _mapService = mapService;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(MapViewModel map)
        {
            _mapService.CreateNewMap(map, _userManager.GetUserId(User));

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult SetVariable(string value)
        {
            string[] mouseXY = value.Split(' ');
            mouseXY[0] = mouseXY[0].Replace('.', ',');
            mouseXY[1] = mouseXY[1].Replace('.', ',');

            X = (int)Math.Round(Convert.ToDouble(mouseXY[0]));
            Y = (int)Math.Round(Convert.ToDouble(mouseXY[1]));

            return Json(new { success = true, x = X, y = Y });
        }

        public IActionResult Index()
        {
            ViewBag.Points = _pointsService.GetPoints();
            return View();
        }
        public int[] GetFromTo(int fromId, int toId)
        {
            return _distanceService.GetTheShortestPath(fromId, toId);
        }
    }
}
