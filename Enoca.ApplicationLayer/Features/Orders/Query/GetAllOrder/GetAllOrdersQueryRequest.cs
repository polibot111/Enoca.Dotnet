using Enoca.ApplicationLayer.Commons;
using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Orders.Query.GetAllOrder
{
    public class GetAllOrdersQueryRequest : PaginationDateRequest, IRequest<IWrapperPaginationResponse<GetAllOrdersQueryResponse>>
    {
    }
}
