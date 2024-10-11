using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Orders.Command.DeleteOrders
{
    public class DeleteOrdersRequest : IRequest<IResponse>
    {
        public int Id { get; set; }
        internal bool SavaChanges { get; set; } = true;
    }
}
