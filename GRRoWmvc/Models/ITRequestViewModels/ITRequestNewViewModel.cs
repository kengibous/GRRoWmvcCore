using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models.ITRequestViewModels
{
    public class ITRequestNewViewModel
    {
        [Required, DisplayName("Description")]
        public string Description { get; set; }

        public List<IFormFile> RequestFiles { get; set; } = new List<IFormFile>();

        public void CopyTo(ITRequest request)
        {
            request.Description = Description;
        }
    }
}
