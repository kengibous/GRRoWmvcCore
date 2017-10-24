using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models.DogUpdateViewModel
{
    public class DogUpdateViewModel
    {
        
        [Required, DisplayName("Create Date")]
        public DateTimeOffset? CreateDate { get; set; }

        [MaxLength(1500)]
        [Required, DisplayName("Details")]
        public string Notes { get; set; }

        [HiddenInput]
        public int DogId { get; set; }

        public void CopyFrom(DogUpdate dogUpdate)
        {
            CreateDate = dogUpdate.CreateDate;
            Notes = dogUpdate.Notes;
            DogId = dogUpdate.Id;
        }

    }
}
