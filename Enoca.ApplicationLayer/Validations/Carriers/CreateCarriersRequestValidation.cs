using Enoca.ApplicationLayer.Features.Carriers.Command.CreateCarriers;
using Enoca.ApplicationLayer.Features.Orders.Command.CreateOrders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Validations.Carriers
{
    public class CreateCarriersRequestValidation : AbstractValidator<CreateCarriersRequest>
    {
        public CreateCarriersRequestValidation()
        {
            RuleFor(p => p.CarrierName).NotEmpty().WithMessage("CarrierName is required");
            RuleFor(p => p.CarrierPlusDesiCost).NotEmpty().WithMessage("CarrierPlusDesiCost is required");

        }
    }
}
