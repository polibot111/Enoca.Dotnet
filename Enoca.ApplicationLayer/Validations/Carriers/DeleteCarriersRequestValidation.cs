using Enoca.ApplicationLayer.Features.Carriers.Command.DeleteCarriers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Validations.Carriers
{
    public class DeleteCarriersRequestValidation : AbstractValidator<DeleteCarriersRequest>
    {

        public DeleteCarriersRequestValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
