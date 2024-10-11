using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.CarrierReports.Query.GetAllCarrierReports
{
    public class GetAllQueryCarrierReportsResponse
    {
        public int Id { get; set; }
        public decimal CarrierCost { get; set; }
        public DateTime CarrierReportDate { get; set; }
        public int CarriersId { get; set; }
        public string CarriersName { get; set; }
    }
}
