using GRRoWmvc.Data.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models.ITRequestViewModels
{
    public class ITRequestEditViewModel
    {
        [HiddenInput]
        [ReadOnly(true)]
        public int ITRequestId { get; set; }

        [MaxLength(2000)]
        [Required, DisplayName("Description")]
        public string Description { get; set; }

        [Required, DisplayName("Status")]
        [EnumDataType(typeof(ITRequestStatusEnum))]
        public ITRequestStatusEnum Status { get; set; }

        [ReadOnly(true)]
        public DateTimeOffset RequestedDate { get; set; }

        [ReadOnly(true)]
        public string RequestedBy { get; set; }

        public List<IFormFile> RequestFiles { get; set; } = new List<IFormFile>();

        public void CopyFrom(ITRequest request)
        {
            ITRequestId = request.Id;
            Description = request.Description;
            RequestedBy = request.RequestedBy;
            RequestedDate = request.RequestedDate.Value;
            Status = request.Status;
        }
        public void CopyTo(ITRequest request)
        {
            request.Description = Description;
            request.Status = Status;
        }
    }
}
