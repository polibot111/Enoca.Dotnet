using Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.CreateCarrierConfigurations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Validations.CarrierConfigurations
{
    public class CreateCarrierConfigurationsRequestValidation : AbstractValidator<CreateCarrierConfigurationsRequest>
    {
        public CreateCarrierConfigurationsRequestValidation()
        {
            RuleFor(RuleFor => RuleFor.CarrierId).NotEmpty().WithMessage("CarrierId is required");
            RuleFor(RuleFor => RuleFor.CarrierCost).NotEmpty().WithMessage("CarrierCost is required");
            RuleFor(RuleFor => RuleFor.CarrierMaxDesi).NotEmpty().WithMessage("CarrierMaxDesi is required");
            RuleFor(RuleFor => RuleFor.CarrierMinDesi).NotEmpty().WithMessage("CarrierMinDesi is required");
            RuleFor(RuleFor => RuleFor.CarrierMaxDesi).GreaterThan(x => x.CarrierMinDesi).NotEmpty().WithMessage("CarrierMaxDesi must be greater than CarrierMinDesi ");
        }
    }
}
