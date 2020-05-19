using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrankoMaps.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FrankoMaps.Controllers
{
    public class DistancesController : Controller
    {
        private readonly ILogger<DistancesController> _logger;
        private readonly DistancesService _distanceService;

        public DistancesController(
            ILogger<DistancesController> logger,
            DistancesService distanceService)
        {
            _logger = logger;
            _distanceService = distanceService;
        }
        public IActionResult Index()
        {
            ViewBag.Distances= _distanceService.GetDistances();
            return View();
        }
    }
}