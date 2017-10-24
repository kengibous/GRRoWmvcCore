using GRRoWmvc.Data.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GRRoWmvc.Models
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(8)]
        [MinLength(6)]
        [RegularExpression(@"\d\d-\d\d\d")]
        [Required]
        public string DogId { get; set; }

        public DateTimeOffset? SurrenderDate { get; set; }

        public DateTimeOffset? AdoptionDate { get; set; }

        public DateTimeOffset? BridgeDate { get; set; }

        [Required]
        public DogGenderEnum Gender { get; set; }

        [Required]
        public double AdoptionFee { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        public DogEnergyEnum EnergyLevel { get; set; }

        [Required]
        public InteractionWithDogsEnum InteractionWithDogs { get; set; }

        [Required]
        public InteractionWithCatsEnum InteractionWithCats { get; set; }

        [Required]
        public InteractionWithKidsEnum InteractionWithKids { get; set; }

        [MaxLength(250)]
        public string Notes { get; set; }

        [Required]
        public DogProfileImage ProfileImage { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public List<DogUpdate> DogUpdates { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public List<DogImage> DogImages { get; set; }

        [Required]
        public DogStatusEnum DogStatus { get; set; }

        public DateTimeOffset? CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset? LastModifiedDate { get; set; }

        public string LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
