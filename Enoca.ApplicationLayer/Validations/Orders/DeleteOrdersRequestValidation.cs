
using Enoca.ApplicationLayer.Features.Orders.Command.DeleteOrders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Validations.Orders
{
    public class DeleteOrdersRequestValidation : AbstractValidator<DeleteOrdersRequest>
    {
        public DeleteOrdersRequestValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
