using GRRoWmvc.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models.DogListViewModels
{
    public class DogListItemViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string DogId { get; set; }        

        public DogGenderEnum Gender { get; set; }

        public string Age { get; set; }

        public DogProfileImage ProfileImage { get; set; }

    }
}
