using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories;
using FrankoMaps.Areas.Identity.Data;
using FrankoMaps.Models;
using FrankoMaps.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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

        [HttpPost]
        public IActionResult Index()
        {
            DistanceRepository distanceRepository = new DistanceRepository();
            List<Distance> distances = distanceRepository.GetItems();

            PointRepository pointRepository = new PointRepository();
            List<Point> points = pointRepository.GetItems();

            List<JoinViewModel> joined = new List<JoinViewModel>();
            foreach (var distance in distances)
            {
                joined.Add(new JoinViewModel
                {
                    Id = distance.Id,
                    FromPointId = distance.FromPointId,
                    NameFrom = points.First(i => i.Id == distance.FromPointId).Name,
                    ToPointId = distance.ToPointId,
                    NameTo = points.First(i => i.Id == distance.ToPointId).Name,
                    Weight = distance.Weight,
                    UserId = distance.UserId
                });
            }

            return View(joined);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(DistanceViewModel distance)
        {
            distance.UserId = _userManager.GetUserId(User);
            _distanceService.Create(distance);

            return RedirectToAction("Manage", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_distanceService.GetDistance(id));
        }

        [HttpPost]
        public IActionResult Edit(DistanceViewModel distance)
        {
            distance.UserId = _userManager.GetUserId(User);
            _distanceService.UpdateDistance(distance);

            return RedirectToAction("Manage", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_distanceService.GetDistance(id));
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            DistanceRepository distanceRepository = new DistanceRepository();
            distanceRepository.Delete(id);

            return RedirectToAction("Manage", "Home");
        }
    }
}