using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.Entities
{
    public class Carriers : BaseEntity
    {
        [Required]
        public string CarrierName { get; set; }

        [Required]
        public bool CarrierIsActive { get; set; }

        [Required]
        public int CarrierPlusDesiCost { get; set; }

        //Reletion
        public List<CarrierConfigurations> CarrierConfigurations { get; set; }
        public List<Orders> Order { get; set; }
        public List<CarrierReports> CarrierReports { get; set; }
    }
}
