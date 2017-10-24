using GRRoWmvc.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRRoWmvc.Models
{
    public class BootstrapModel
    {
        public string ID { get; set; }
        public string AreaLabeledId { get; set; }
        public ModalSizeEnum Size { get; set; }
        public string Message { get; set; }
        public string ModalSizeClass
        {
            get
            {
                switch (this.Size)
                {
                    case ModalSizeEnum.Small:
                        return "modal-sm";
                    case ModalSizeEnum.Large:
                        return "modal-lg";
                    case ModalSizeEnum.Medium:
                    default:
                        return "";
                }
            }
        }
    }
}
