using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GRRoWmvc.Data;
using GRRoWmvc.Models.DogViewModels;
using GRRoWmvc.Models;
using System.IO;
using ImageSharp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GRRoWmvc.Controllers
{
    [Authorize]
    public class DogController : Controller
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public DogController(
            UserManager<ApplicationUser> userManager,
            ILogger<DogController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult NewDog()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewDog(NewDogViewModel model)
        {
            if (ModelState.IsValid)
            {
                Dog newDog = new Dog()
                {
                    CreateDate = DateTimeOffset.UtcNow,
                    CreatedBy = _userManager.GetUserName(User),
                    LastModifiedBy = _userManager.GetUserName(User),
                    LastModifiedDate = DateTimeOffset.UtcNow
                };
                model.CopyTo(newDog);
                
                await _dbContext.AddAsync<Dog>(newDog);
                await _dbContext.SaveChangesAsync();

                foreach (var dogImage in model.DogImages)
                {
                    if (dogImage.Length > 0)
                    {
                        MemoryStream outputStream = new MemoryStream();                        
                        using (var image = Image.Load(dogImage.OpenReadStream()))
                        {
                            image
                                .Resize(800, 600)
                                .SaveAsJpeg(outputStream);
                        }
                        DogImage dogImageToSave = new DogImage()
                        {
                            Dog = newDog,
                            Height = 600,
                            Width = 800,
                            ImageData = outputStream.ToArray(),
                            ImageName = newDog.DogId + "-" + Guid.NewGuid().ToString() + ".jpeg"
                        };
                        await _dbContext.AddAsync<DogImage>(dogImageToSave);
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DogList()
        {
            var dogs =  _dbContext.Dogs.Where(x=> !x.IsDeleted).Take(10).OrderByDescending(d => d.DogId).Select(x => new DogListItemViewModel()
            {
                Id = x.Id,
                DogId = x.DogId,
                DogStatus = x.DogStatus,
                Gender = x.Gender,
                Name = x.Name
            });
            return View(await dogs.ToListAsync());
        }

        public async Task<IActionResult> DeleteDogImage(int dogId, int imageId)
        {
            var image = await _dbContext.DogImages.FindAsync(imageId);
            if (image == null)
                return RedirectToAction("Edit", dogId);
            _dbContext.DogImages.Remove(image);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = dogId} );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dog = await _dbContext.Dogs
                .Include(x => x.DogImages)
                .Include(x => x.ProfileImage)
                .FirstOrDefaultAsync(x=> x.Id == id);
            if (dog == null)
               return RedirectToAction("DogList");
            DogEditViewModel editModel = new DogEditViewModel();
            editModel.CopyFrom(dog);
            return View(editModel);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var dog = await _dbContext.Dogs
                .Include(x => x.DogUpdates)
                .Include(x => x.DogImages)
                .Include(x => x.ProfileImage)
                .FirstOrDefaultAsync(x => x.Id == id);
            var dogViewModel = new DogViewViewModel();
            dogViewModel.CopyFrom(dog);            
            return View(dogViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dog = await _dbContext.FindAsync<Dog>(id);
            if (dog == null)
                return RedirectToAction("DogList");

            dog.IsDeleted = true;
            dog.LastModifiedDate = DateTimeOffset.UtcNow;
            dog.LastModifiedBy = _userManager.GetUserName(User);

            await _dbContext.SaveChangesAsync();
            return RedirectToAction("DogList");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DogEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dog = await _dbContext.Dogs
                    .Include(x => x.DogImages)
                    .Include(x => x.ProfileImage)
                    .FirstOrDefaultAsync(x => x.Id == model.Id);

                if (model.ProfileImage != null)
                {
                    _dbContext.Remove<DogProfileImage>(dog.ProfileImage);
                    await _dbContext.SaveChangesAsync();
                }

                dog.LastModifiedBy = _userManager.GetUserName(User);
                dog.LastModifiedDate = DateTimeOffset.UtcNow;
                //TODO: handle null
                if (dog == null)
                    RedirectToAction("DogList");

                
                model.CopyTo(dog);
                foreach (var dogImage in model.DogImages)
                {
                    if (dogImage.Length > 0)
                    {
                        MemoryStream outputStream = new MemoryStream();
                        using (var image = Image.Load(dogImage.OpenReadStream()))
                        {
                            image
                                .Resize(800, 600)
                                .SaveAsJpeg(outputStream);
                        }
                        DogImage dogImageToSave = new DogImage()
                        {
                            Dog = dog,
                            Height = 600,
                            Width = 800,
                            ImageData = outputStream.ToArray(),
                            ImageName = dog.DogId + "-" + Guid.NewGuid().ToString() + ".jpeg"
                        };
                        await _dbContext.AddAsync<DogImage>(dogImageToSave);
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("DogList");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}