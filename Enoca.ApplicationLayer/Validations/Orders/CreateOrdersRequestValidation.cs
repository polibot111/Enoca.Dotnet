using Enoca.ApplicationLayer.Features.Orders.Command.CreateOrders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Validations.Orders
{
    public class CreateOrdersRequestValidation : AbstractValidator<CreateOrdersRequest>
    {
        public CreateOrdersRequestValidation()
        {
            RuleFor(x => x.OrderDesi).NotEmpty().WithMessage("OrderDesi is required");
        }
    }
}
