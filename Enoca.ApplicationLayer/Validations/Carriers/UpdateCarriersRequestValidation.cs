using Enoca.ApplicationLayer.Features.Carriers.Command.UpdateCarriers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Validations.Carriers
{
    public class UpdateCarriersRequestValidation : AbstractValidator<UpdateCarriersRequest>
    {
        public UpdateCarriersRequestValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.CarrierName).NotEmpty().WithMessage("CarrierName is required");
            RuleFor(x => x.CarrierPlusDesiCost).NotEmpty().WithMessage("CarrierCode is required");

        }
    }
}
