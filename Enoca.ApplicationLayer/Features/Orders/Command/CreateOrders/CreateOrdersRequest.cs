using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Orders.Command.CreateOrders
{
    public class CreateOrdersRequest : IRequest<IResponse>
    {
        [Required]
        public int OrderDesi { get; set; }


    }
}
