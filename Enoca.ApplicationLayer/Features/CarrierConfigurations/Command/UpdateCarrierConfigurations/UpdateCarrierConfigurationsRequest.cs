using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.UpdateCarrierConfigurations
{
    public class UpdateCarrierConfigurationsRequest : IRequest<IResponse>
    {
        public int Id { get; set; }
        public int CarrierMaxDesi { get; set; }

        public int CarrierMinDesi { get; set; }

        public decimal CarrierCost { get; set; }

        public int CarrierId { get; set; }
    }
}
