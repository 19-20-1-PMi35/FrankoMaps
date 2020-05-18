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

        [HttpGet]
        public ActionResult Create()
        {
            string userId = _userManager.GetUserId(User);

            ViewBag.UserId = userId;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(MapViewModel map)
        {
            _mapService.CreateNewMap(map, _userManager.GetUserId(User));

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
