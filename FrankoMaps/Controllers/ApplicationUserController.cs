using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrankoMaps.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FrankoMaps.Controllers
{
    [Authorize]
    public class ApplicationUserController : Controller
    {
        private readonly ILogger<ApplicationUserController> _logger;

        public UserManager<ApplicationUser> UserManager { get; private set; }
        public ApplicationUserController(
            ILogger<ApplicationUserController> logger, 
            UserManager<ApplicationUser> _userManager)
        {
            _logger = logger;
            UserManager = _userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}