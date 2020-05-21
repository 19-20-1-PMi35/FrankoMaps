using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrankoMaps.Models;
using FrankoMaps.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FrankoMaps.Areas.Identity.Data;
using DataAccess.Repositories;
using DataAccess.Entities;

namespace FrankoMaps.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly ILogger<PointsController> _logger;
        private readonly FavouritesService _favouritesService;
        private readonly UserManager<ApplicationUser> _userManager;
        public FavouriteController(ILogger<PointsController> logger, FavouritesService favouritesService, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _favouritesService = favouritesService;
            _userManager = userManager;
        }

        [HttpPost]
         public ActionResult Create(int start, int end)
         {
             FavouriteViewModel favourite = new FavouriteViewModel() { PointA_Id = start, PointB_Id = end , User_Id = _userManager.GetUserId(User)};
             _favouritesService.Create(favourite);

             return Json(new { success = true });
         }

        public IActionResult Index()
        {
            return View();
        }
    }
}