using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GRRoWmvc.Data.Enums;
using GRRoWmvc.Data;
using Microsoft.Extensions.Logging;
using GRRoWmvc.Models;
using Microsoft.EntityFrameworkCore;
using GRRoWmvc.Models.DogListViewModels;

namespace GRRoWmvc.Controllers
{
    public class DogListController : Controller
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;

        public DogListController(
            ILogger<DogListController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        public async Task<IActionResult> DogList(
            DogStatusEnum? dogType,
            int? page)
        {
            if (dogType == null)
                dogType = DogStatusEnum.InFosterCare;

            ViewData["CurrentType"] = dogType;            

            if (page == null)
            {
                page = 1;
            }


            var dogs = GetDogs(dogType.Value);
            
            int pageSize = 1;
            return View(await PaginatedList<DogListItemViewModel>.CreateAsync(dogs.AsNoTracking(), page ?? 1, pageSize));
        }

        private IQueryable<DogListItemViewModel> GetDogs(DogStatusEnum dogType)
        {
            if (dogType == DogStatusEnum.BehavioralHold || dogType == DogStatusEnum.ForeverFoster || dogType == DogStatusEnum.MedicalHold)
            {
                return _dbContext.Dogs
                    .Include( x=> x.ProfileImage )
                    .Where(x => x.DogStatus == DogStatusEnum.MedicalHold ||
                        x.DogStatus == DogStatusEnum.InFosterCare ||
                        x.DogStatus == DogStatusEnum.BehavioralHold)
                    .OrderByDescending(x => x.LastModifiedDate)
                    .Select(x=> new DogListItemViewModel()
                    {
                        Age = x.Age,
                        DogId = x.DogId,
                        Gender = x.Gender,
                        Id = x.Id,
                        Name = x.Name,
                        ProfileImage = x.ProfileImage
                    });
            }
            else
            {
                return _dbContext.Dogs
                    .Include(x => x.ProfileImage)
                    .Where(x => x.DogStatus == dogType)
                    .OrderByDescending(x => x.LastModifiedDate)
                    .Select(x => new DogListItemViewModel()
                    {
                        Age = x.Age,
                        DogId = x.DogId,
                        Gender = x.Gender,
                        Id = x.Id,
                        Name = x.Name,
                        ProfileImage = x.ProfileImage
                    });
            }

        }
    }
}