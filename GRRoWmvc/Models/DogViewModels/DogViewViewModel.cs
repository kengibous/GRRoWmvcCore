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

        public List<string> CurrentImages { get; set; } = new List<string>();

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
            foreach (var image in dog.DogImages)
            {
                string base64String = Convert.ToBase64String(image.ImageData);
                //<img alt="Embedded Image" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADIA..." />
                imageList.Add("data:image/" +
                    image.ImageName.Substring(image.ImageName.LastIndexOf('.')) + ";base64," +
                    base64String);
            }
            foreach ( var update in dog.DogUpdates)
            {
                var updateView = new DogUpdateViewModel.DogUpdateViewModel();
                updateView.CopyFrom(update);
                this.DogUpdates.Add(updateView);
            }
            CurrentImages = imageList;
        }
    }
}
