using GRRoWmvc.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models.ITRequestViewModels
{
    public class ITRequestDetailsViewModel
    {
        [ReadOnly(true)]
        public int Id { get; set; }

        [ReadOnly(true)]
        public ITRequestStatusEnum Status { get; set; }
        
        [ReadOnly(true)]
        public string Description { get; set; }

        [ReadOnly(true)]
        public string RequestedBy { get; set; }

        [ReadOnly(true)]
        public DateTimeOffset? RequestedDate { get; set; }

        [ReadOnly(true)]
        public string CompletedBy { get; set; }

        [ReadOnly(true)]
        public DateTimeOffset? CompletedDate { get; set; }

        [ReadOnly(true)]
        public string CompletionNotes { get; set; }

        public Dictionary<int, string> RequestFiles { get; set; }

        public void CopyFrom(ITRequest request)
        {
            Id = request.Id;
            Description = request.Description;
            Status = request.Status;
            RequestedBy = request.RequestedBy;
            RequestedDate = request.RequestedDate.Value;
            CompletedBy = request.CompletedBy;
            CompletedDate = request.CompletedDate;
            CompletionNotes = request.CompletionNotes;
            this.RequestFiles = new Dictionary<int, string>();
            request.ITRequestFiles.ForEach(f => RequestFiles.Add(f.Id, f.FileName));
        }
    }
}
