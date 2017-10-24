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
    public class ITRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ITRequestStatusEnum Status { get; set; }

        [MaxLength(2000)]
        [Required]
        public string Description { get; set; }

        [Required]
        [MaxLength(200)]
        public string RequestedBy { get; set; }

        public DateTimeOffset? RequestedDate { get; set; }

        [MaxLength(200)]
        public string CompletedBy { get; set; }

        public DateTimeOffset? CompletedDate { get; set; }        

        [XmlIgnore]
        [JsonIgnore]
        public List<ITRequestFile> ITRequestFiles { get; set; }

        [MaxLength(2000)]
        public string CompletionNotes { get; set; }

    }
}
