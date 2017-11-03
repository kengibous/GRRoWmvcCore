using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models.DogUpdateViewModel
{
    public class DogUpdateCreateViewModel
    {
        
        [Required, DisplayName("Create Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset? CreateDate { get; set; }

        [MaxLength(1500)]
        [Required, DisplayName("Details")]
        public string Notes { get; set; }

        [HiddenInput]
        public int DogId { get; set; }

        public void CopyTo(DogUpdate dogUpdate)
        {
            dogUpdate.CreateDate = CreateDate;
            dogUpdate.Notes = Notes;
            dogUpdate.Id = DogId;
        }

    }
}
