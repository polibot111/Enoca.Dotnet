using Enoca.ApplicationLayer.Features.CarrierConfigurations.Query.GetAllCarrierConfigurations;
using Enoca.ApplicationLayer.Features.Carriers.Query.GetAllCarriers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Orders.Query.GetAllOrder
{
    public class GetAllOrdersQueryResponse
    {
        public int Id { get; set; }

        public int OrderDesi { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderCarrierCost { get; set; }

        public int CarrierId { get; set; }
        public string CarrierName{ get; set; }


    }
}
