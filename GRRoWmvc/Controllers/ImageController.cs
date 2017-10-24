using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GRRoWmvc.Data;
using Microsoft.AspNetCore.Identity;
using GRRoWmvc.Models;
using Microsoft.AspNetCore.Authorization;

namespace GRRoWmvc.Controllers
{
    [Authorize]
    public class ImageController : Controller
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ImageController(
            UserManager<ApplicationUser> userManager,
            ILogger<ImageController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public IActionResult DeleteImage(int id)
        {            
            return View();
        }
    }
}