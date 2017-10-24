using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models
{
    public class DogImage
    {
        [Key]
        public int Id { get; set; }

        public byte[] ImageData { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ImageName { get; set; }

        public int DogId { get; set; }
        public Dog Dog { get; set; }
    }
}
