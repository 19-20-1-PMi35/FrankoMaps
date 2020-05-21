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
using System.Collections.Generic;

namespace FrankoMaps.Controllers
{
    public class MapsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PointsService _pointsService;
        private readonly DistancesService _distanceService;
        private readonly MapsService _mapService;
        private readonly UserManager<ApplicationUser> _userManager;

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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateMap()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(MapViewModel map)
        {
            map.UserId = _userManager.GetUserId(User);
            _mapService.Create(map);

            return RedirectToAction("Index", "Maps");
        }

        public IActionResult Index()
        {
            ViewBag.Points = _pointsService.GetPoints();
            ViewBag.Maps = _mapService.GetMaps();
            return View();
        }
        public int[] GetFromTo(int fromId, int toId,int mapId)
        {
            return _distanceService.GetTheShortestPath(fromId, toId, mapId);
        }
        public List<MapViewModel> GetMaps()
        {
            return _mapService.GetMaps();
        }
    }
}
