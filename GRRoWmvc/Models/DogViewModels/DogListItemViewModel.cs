using GRRoWmvc.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models.DogViewModels
{
    public class DogListItemViewModel
    {
        public int Id { get; set; }
        
        [DisplayName("Dog Name")]
        public string Name { get; set; }

        [DisplayName("Dog Id")]
        public string DogId { get; set; }

        [DisplayName("Status")]
        public DogStatusEnum DogStatus { get; set; }
        
        public DogGenderEnum Gender { get; set; }

    }
}
