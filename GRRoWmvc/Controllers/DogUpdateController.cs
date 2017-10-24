using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GRRoWmvc.Data;
using GRRoWmvc.Models.DogUpdateViewModel;
using GRRoWmvc.Models;
using Microsoft.AspNetCore.Authorization;

namespace GRRoWmvc.Controllers
{
    [Authorize]
    public class DogUpdateController : Controller
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;

        public DogUpdateController(
            ILogger<DogUpdateController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var update = new DogUpdateCreateViewModel() { DogId = id };
            return View(update);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DogUpdateCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dogUpdate = new DogUpdate()
                {
                    CreateDate = model.CreateDate,
                    DogId = model.DogId,
                    Notes = model.Notes
                };
                await _dbContext.AddAsync<DogUpdate>(dogUpdate);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("DogList", "Dog");
        }
    }
}