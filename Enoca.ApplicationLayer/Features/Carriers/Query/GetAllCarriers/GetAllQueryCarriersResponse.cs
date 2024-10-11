using Enoca.ApplicationLayer.Features.CarrierConfigurations.Query.GetAllCarrierConfigurations;
using Enoca.ApplicationLayer.Features.Orders.Query.GetAllOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Carriers.Query.GetAllCarriers
{
    public class GetAllQueryCarriersResponse
    {
        public int Id { get; set; }

        public string CarrierName { get; set; }

        public bool CarrierIsActive { get; set; }

        public int CarrierPlusDesiCost { get; set; }

        public List<GetAllOrdersQueryResponse> Orders { get; set; }
        public List<GetAllQueryCarrierConfigurationsResponse> CarrierConfigurations { get; set; }


    }
}
