using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.Entities
{
    public class Orders : BaseEntity
    {
        [Required]
        public int OrderDesi { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal OrderCarrierCost { get; set; }

        [Required]
        public int CarrierId { get; set; }

        public bool IsReported { get; set; } = false;

        //Reletion
        public Carriers Carrier { get; set; }
    }
}
