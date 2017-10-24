using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models
{
    public class DogUpdate
    {        
        [Key]
        public int Id { get; set; }
        public DateTimeOffset? CreateDate { get; set; }

        [MaxLength(1500)]
        public string Notes { get; set; }

        public int DogId { get; set; }
        public Dog Dog { get; set; }
    }
}
