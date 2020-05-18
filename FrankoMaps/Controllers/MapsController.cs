using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrankoMaps.Models;
using FrankoMaps.Services;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using FrankoMaps.Areas.Identity.Data;

namespace FrankoMaps.Controllers
{
    public class MapsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DistancesService _distanceService;
        private readonly PointsService _pointsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MapsController(
            ILogger<HomeController> logger,
            DistancesService distancesService,
            PointsService pointsService,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _distanceService = distancesService;
            _pointsService = pointsService;
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
            Map newMap = new Map() { Image = map.Image, UserId = _userManager.GetUserId(HttpContext.User) };

            MapRepository mapRepository = new MapRepository();
            //mapRepository.Create(newMap);

            return RedirectToAction("Index", "Home");
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
