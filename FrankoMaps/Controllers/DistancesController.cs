﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repositories;
using FrankoMaps.Areas.Identity.Data;
using FrankoMaps.Models;
using FrankoMaps.Services;
using Microsoft.AspNetCore.Authorization;
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
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(DistanceViewModel distance)
        {
            _distanceService.Create(distance, _userManager.GetUserId(User));

            return RedirectToAction("Index", "Distance");
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

            return RedirectToAction("Index", "Distances");
        }
    }
}