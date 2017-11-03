using GRRoWmvc.Data.Enums;
using ImageSharp;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models.DogViewModels
{
    public class NewDogViewModel
    {
        [MaxLength(8)]
        [MinLength(6)]
        [RegularExpression(@"\d\d-\d\d\d")]
        [Required, DisplayName("Dog Id")]
        public string DogId { get; set; }

        [MaxLength(50)]
        [Required, DisplayName("Dog Name")]
        public string Name { get; set; }

        [Required, DisplayName("Dog Status")]
        [EnumDataType(typeof(DogStatusEnum))]
        public DogStatusEnum Status { get; set; }

        [Required, DisplayName("Surrender Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset SurrenderDate { get; set; }

        [Required]
        [EnumDataType(typeof(DogGenderEnum))]
        public DogGenderEnum Gender { get; set; }

        [Required]
        public string Age { get; set; }

        [Required, DisplayName("Energy Level")]
        [EnumDataType(typeof(DogEnergyEnum))]
        public DogEnergyEnum EnergyLevel { get; set; }

        [Required, DisplayName("Interactions with Dogs")]
        [EnumDataType(typeof(InteractionWithDogsEnum))]
        public InteractionWithDogsEnum InteractionWithDogs { get; set; }

        [Required, DisplayName("Interactions with Cats")]
        [EnumDataType(typeof(InteractionWithCatsEnum))]
        public InteractionWithCatsEnum InteractionWithCats { get; set; }

        [Required, DisplayName("Interactions with Children")]
        [EnumDataType(typeof(InteractionWithKidsEnum))]
        public InteractionWithKidsEnum InteractionWithKids { get; set; }

        [MaxLength(250)]
        public string Notes { get; set; }

        [Required, DisplayName("Profile Image")]        
        public IFormFile ProfileImage { get; set; }

        [DisplayName("Additional Images")]
        public List<IFormFile> DogImages { get; set; } = new List<IFormFile>();

        public void CopyTo(Dog dog)
        {
            dog.DogId = DogId;
            dog.Name = Name;
            dog.Age = Age;
            dog.SurrenderDate = SurrenderDate;
            dog.Gender = Gender;
            dog.EnergyLevel = EnergyLevel;
            dog.InteractionWithCats = InteractionWithCats;
            dog.InteractionWithDogs = InteractionWithDogs;
            dog.InteractionWithKids = InteractionWithKids;
            dog.Notes = Notes;
            dog.DogStatus = Status;
            
            if (ProfileImage?.Length > 0)
            {
                MemoryStream outputStream = new MemoryStream();
                using (var image = Image.Load(ProfileImage.OpenReadStream()))
                {
                    image
                        .Resize(800, 600)
                        .SaveAsJpeg(outputStream);
                }
                DogProfileImage dogImageToSave = new DogProfileImage()
                {
                    Dog = dog,
                    Height = 600,
                    Width = 800,
                    ImageData = outputStream.ToArray(),
                    ImageName = dog.DogId + "-profile-" + Guid.NewGuid().ToString() + ".jpeg"
                };
                dog.ProfileImage = dogImageToSave;
            }
            
        }

    }
}
