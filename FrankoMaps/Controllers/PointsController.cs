using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrankoMaps.Models;
using FrankoMaps.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FrankoMaps.Areas.Identity.Data;

namespace FrankoMaps.Controllers
{
    public class PointsController : Controller
    {
        private readonly ILogger<PointsController> _logger;
        private readonly PointsService _pointsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PointsController(
            ILogger<PointsController> logger,
            PointsService pointsService,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _pointsService = pointsService;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Create(int mapId, int x, int y)
        {
            ViewBag.MapId = mapId;
            ViewBag.X = x;
            ViewBag.Y = y;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(PointViewModel point)
        {
            _pointsService.Create(point, _userManager.GetUserId(User));

            return RedirectToAction("Index", "Maps");
        }

        public IActionResult Index()
        {
            ViewBag.Points = _pointsService.GetPoints();
            return View();
        }
        public List<PointViewModel> GetPoints(int fromId, int toId)
        {
            return _pointsService.GetPoints();
        }
    }
}
