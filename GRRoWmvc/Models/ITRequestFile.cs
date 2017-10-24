using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models
{
    public class ITRequestFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] FileData { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(255)]
        public string FileType { get; set; }
        
        public int ITRequestId { get; set; }
        public ITRequest ITRequest { get; set; }
    }
}
