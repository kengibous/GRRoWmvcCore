using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GRRoWmvc.Data;
using GRRoWmvc.Models.ITRequestViewModels;
using Microsoft.EntityFrameworkCore;
using GRRoWmvc.Models;
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace GRRoWmvc.Controllers
{
    public class ITRequestController : Controller
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser>_userManager;

        public ITRequestController(UserManager<ApplicationUser> userManager,
            ILogger<ITRequestController> logger,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Download(int id)
        {
            var file = await _dbContext.ITRequestFiles.FindAsync(id);

            return File(file.FileData, file.FileType, file.FileName);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var request = await _dbContext.ITRequests
                .Include(x => x.ITRequestFiles)                
                .FirstOrDefaultAsync(x => x.Id == id);
            var model = new ITRequestDetailsViewModel();
            model.CopyFrom(request);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Complete(int id)
        {
            var request = await _dbContext.ITRequests
                .FindAsync(id);
            var model = new ITRequestCompleteViewModel()
            {
                Id = request.Id,
                CompletionNotes = request.CompletionNotes
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Complete(ITRequestCompleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var request = await _dbContext.ITRequests
                    .FirstOrDefaultAsync(x => x.Id == model.Id);
                //TODO: handle null
                if (request == null)
                    RedirectToAction("List");

                request.CompletionNotes = model.CompletionNotes;
                request.CompletedBy = _userManager.GetUserName(User);
                request.CompletedDate = DateTimeOffset.UtcNow;
                request.Status = Data.Enums.ITRequestStatusEnum.Complete;
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var request = await _dbContext.FindAsync<ITRequest>(id);
            var editModel = new ITRequestEditViewModel();
            editModel.CopyFrom(request);
            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ITRequestEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var request = await _dbContext.ITRequests
                    .Include(x => x.ITRequestFiles)
                    .FirstOrDefaultAsync(x => x.Id == model.ITRequestId);
                //TODO: handle null
                if (request == null)
                    RedirectToAction("List");

                model.CopyTo(request);
                foreach (var file in model.RequestFiles)
                {
                    if (file.Length > 0)
                    {

                        byte[] buffer = new byte[file.Length];
                        file.OpenReadStream().Read(buffer, 0, (int)file.Length);

                        var requestFile = new ITRequestFile()
                        {
                            FileData = buffer,
                            FileName = file.FileName,
                            FileType = file.ContentType,
                            ITRequest = request
                        };
                        await _dbContext.AddAsync<ITRequestFile>(requestFile);
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ITRequestNewViewModel model)
        {
            if (ModelState.IsValid)
            {
                ITRequest request = new ITRequest()
                {
                    RequestedBy = _userManager.GetUserName(User),
                    RequestedDate = DateTimeOffset.Now
                };
                model.CopyTo(request);
                await _dbContext.AddAsync<ITRequest>(request);
                await _dbContext.SaveChangesAsync();

                foreach (var file in model.RequestFiles)
                {
                    if (file.Length > 0)
                    {
                        byte[] buffer = new byte[file.Length];
                        file.OpenReadStream().Read(buffer, 0, (int)file.Length);

                        var requestFile = new ITRequestFile()
                        {
                            FileData = buffer,
                            FileName = file.FileName,
                            FileType = file.ContentType,
                            ITRequest = request
                        };
                        await _dbContext.AddAsync<ITRequestFile>(requestFile);
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var requests = _dbContext.ITRequests.Take(10).OrderByDescending(i => i.Id).Select(x => new ITRequestListViewModel()
            {
                CompletedBy = x.CompletedBy,
                CompletedDate = x.CompletedDate,
                Id = x.Id,
                Description = x.Description.Substring(0, 20),
                RequestedBy = x.RequestedBy,
                RequestedDate = x.RequestedDate,
                Status = x.Status
            });
            return View(await requests.ToListAsync());
        }        
    }
}