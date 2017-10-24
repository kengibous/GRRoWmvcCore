using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models.ITRequestViewModels
{
    public class ITRequestCompleteViewModel
    {
        [HiddenInput]
        public int Id { get; set; }        
        
        [MaxLength(2000)]
        [DisplayName("Completion Notes")]
        public string CompletionNotes { get; set; }
    }
}
