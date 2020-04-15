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
    public class PointsController : Controller
    {
        private readonly ILogger<PointsController> _logger;
        private readonly PointsService _pointsService;

        public PointsController(
            ILogger<PointsController> logger,
            PointsService pointsService)
        {
            _logger = logger;
            _pointsService = pointsService;
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
