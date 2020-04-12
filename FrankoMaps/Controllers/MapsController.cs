using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrankoMaps.Models;
using FrankoMaps.Services;

namespace FrankoMaps.Controllers
{
    public class MapsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DistancesService _distanceService;
        private readonly PointsService _pointsService;

        public MapsController(
            ILogger<HomeController> logger,
            DistancesService distancesService,
            PointsService pointsService)
        {
            _logger = logger;
            _distanceService = distancesService;
            _pointsService = pointsService;
        }

        public IActionResult Index()
        {
            ViewBag.Points = _pointsService.GetPoints();
            return View();
        }
    }
}
