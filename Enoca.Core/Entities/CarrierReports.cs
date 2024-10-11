using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.Entities
{
    public class CarrierReports : BaseEntity
    {
        public decimal CarrierCost { get; set; }
        public DateTime CarrierReportDate{ get; set; }
        public int CarriersId { get; set; }

        //Reletion
        public Carriers Carriers { get; set; }
    }
}
