using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.CarrierConfigurations.Query.GetAllCarrierConfigurations
{
    public class GetAllQueryCarrierConfigurationsResponse
    {
        public int Id { get; set; }
        public int CarrierMaxDesi { get; set; }

        public int CarrierMinDesi { get; set; }

        public decimal CarrierCost { get; set; }

        public int CarrierId { get; set; }

        public string CarrierName { get; set; }
    }
}
