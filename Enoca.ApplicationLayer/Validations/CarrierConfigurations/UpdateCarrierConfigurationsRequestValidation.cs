using Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.UpdateCarrierConfigurations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Validations.CarrierConfigurations
{
    public class UpdateCarrierConfigurationsRequestValidation : AbstractValidator<UpdateCarrierConfigurationsRequest>
    {
        public UpdateCarrierConfigurationsRequestValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.CarrierId).NotEmpty().WithMessage("CarrierId is required");
            RuleFor(x => x.CarrierCost).NotEmpty().WithMessage("CarrierCost is required");
            RuleFor(x => x.CarrierMaxDesi).NotEmpty().WithMessage("CarrierMaxDesi is required");
            RuleFor(x => x.CarrierMinDesi).NotEmpty().WithMessage("CarrierMinDesi is required");
            RuleFor(x => x.CarrierMaxDesi).GreaterThan(x => x.CarrierMinDesi).NotEmpty().WithMessage("CarrierMaxDesi must be greater than CarrierMinDesi ");

        }
    }
}
