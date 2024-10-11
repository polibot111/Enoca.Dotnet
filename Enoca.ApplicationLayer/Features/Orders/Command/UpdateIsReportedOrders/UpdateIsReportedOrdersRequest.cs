using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Orders.Command.UpdateIsReportedOrders
{
    public class UpdateIsReportedOrdersRequest : IRequest<IResponse>
    {
        public int Id { get; set; }
    }
}
