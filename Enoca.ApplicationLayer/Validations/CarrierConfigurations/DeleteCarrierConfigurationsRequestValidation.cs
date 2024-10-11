using Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.DeleteCarrierConfigurations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Validations.CarrierConfigurations
{
    public class DeleteCarrierConfigurationsRequestValidation : AbstractValidator<DeleteCarrierConfigurationsRequest>
    {
        public DeleteCarrierConfigurationsRequestValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
