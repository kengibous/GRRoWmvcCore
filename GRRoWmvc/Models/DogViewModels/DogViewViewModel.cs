using GRRoWmvc.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models.DogViewModels
{
    public class DogViewViewModel
    {
        [ReadOnly(true)]
        [DisplayName("Dog Id")]
        public string DogId { get; set; }

        [ReadOnly(true)]
        [DisplayName("Dog Name")]
        public string Name { get; set; }

        [ReadOnly(true)]
        [DisplayName("Dog Status")]
        [EnumDataType(typeof(DogStatusEnum))]
        public DogStatusEnum Status { get; set; }

        [ReadOnly(true)]
        [DisplayName("Surrender Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset SurrenderDate { get; set; }

        [ReadOnly(true)]
        [EnumDataType(typeof(DogGenderEnum))]
        public DogGenderEnum Gender { get; set; }

        [ReadOnly(true)]
        public string Age { get; set; }

        [ReadOnly(true)]
        [DisplayName("Energy Level")]
        [EnumDataType(typeof(DogEnergyEnum))]
        public DogEnergyEnum EnergyLevel { get; set; }

        [ReadOnly(true)]
        [DisplayName("Interactions with Dogs")]
        [EnumDataType(typeof(InteractionWithDogsEnum))]
        public InteractionWithDogsEnum InteractionWithDogs { get; set; }

        [ReadOnly(true)]
        [DisplayName("Interactions with Cats")]
        [EnumDataType(typeof(InteractionWithCatsEnum))]
        public InteractionWithCatsEnum InteractionWithCats { get; set; }

        [ReadOnly(true)]
        [DisplayName("Interactions with Children")]
        [EnumDataType(typeof(InteractionWithKidsEnum))]
        public InteractionWithKidsEnum InteractionWithKids { get; set; }

        public List<DogImage> CurrentDogImages { get; set; } = new List<DogImage>();

        public DogProfileImage CurrentProfile { get; set; }

        public List<DogUpdateViewModel.DogUpdateViewModel> DogUpdates { get; set; } = new List<DogUpdateViewModel.DogUpdateViewModel>();
        
        public void CopyFrom(Dog dog)
        {
            DogId = dog.DogId;
            Name = dog.Name;
            Age = dog.Age;
            SurrenderDate = dog.SurrenderDate.Value;
            Gender = dog.Gender;
            EnergyLevel = dog.EnergyLevel;
            InteractionWithCats = dog.InteractionWithCats;
            InteractionWithDogs = dog.InteractionWithDogs;
            InteractionWithKids = dog.InteractionWithKids;
            Status = dog.DogStatus;
            var imageList = new List<string>();

            if (dog.ProfileImage != null)
            {
                this.CurrentProfile = dog.ProfileImage;
            }

            foreach (var image in dog.DogImages)
            {
                string base64String = Convert.ToBase64String(image.ImageData);
                //<img alt="Embedded Image" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADIA..." />
                imageList.Add("data:image/" +
                    image.ImageName.Substring(image.ImageName.LastIndexOf('.')) + ";base64," +
                    base64String);
            }
            foreach (var image in dog.DogImages)
            {
                this.CurrentDogImages.Add(image);
            }
            if(dog.DogUpdates?.Count > 0)
            {
                this.DogUpdates = dog.DogUpdates.OrderByDescending(du => du.CreateDate).Select(du => new DogUpdateViewModel.DogUpdateViewModel
                {
                    CreateDate = du.CreateDate,
                    DogId = du.DogId,
                    Notes = du.Notes
                }).ToList();
            }
        }
    }
}
