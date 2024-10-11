using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.CreateCarrierConfigurations
{
    public class CreateCarrierConfigurationsRequest : IRequest<IResponse>
    {
        public int CarrierMaxDesi { get; set; }

        public int CarrierMinDesi { get; set; }

        public decimal CarrierCost { get; set; }

        public int CarrierId { get; set; }
    }
}
