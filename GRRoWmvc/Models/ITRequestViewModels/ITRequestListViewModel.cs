﻿using GRRoWmvc.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models.ITRequestViewModels
{
    public class ITRequestListViewModel
    {
        [ReadOnly(true)]
        public int Id { get; set; }

        [ReadOnly(true)]
        [DisplayName("Status")]
        public ITRequestStatusEnum Status { get; set; }

        [ReadOnly(true)]
        public string Description { get; set; }

        [ReadOnly(true)]
        [DisplayName("Requested By")]
        public string RequestedBy { get; set; }

        [ReadOnly(true)]
        [DisplayName("Request Date")]
        public DateTimeOffset? RequestedDate { get; set; }

        [ReadOnly(true)]
        [DisplayName("Completed By")]
        public string CompletedBy { get; set; }

        [ReadOnly(true)]
        [DisplayName("Completed Date")]
        public DateTimeOffset? CompletedDate { get; set; }

    }
}
