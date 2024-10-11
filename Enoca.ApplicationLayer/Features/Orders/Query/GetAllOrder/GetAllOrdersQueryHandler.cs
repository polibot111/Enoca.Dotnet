using Enoca.ApplicationLayer.Commons;
using Enoca.ApplicationLayer.Features.Carriers.Query.GetAllCarriers;
using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Orders.Query.GetAllOrder
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, IWrapperPaginationResponse<GetAllOrdersQueryResponse>>
    {
        private readonly IOrdersRepository _ordersRepository;

        public GetAllOrdersQueryHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<IWrapperPaginationResponse<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _ordersRepository.GetAllQuerablePagedReponseAsync(request);

            var realResponse = await result.Data.Select(x => new GetAllOrdersQueryResponse()
            {
                Id = x.Id,
                OrderCarrierCost = x.OrderCarrierCost,
                OrderDate = x.OrderDate,
                OrderDesi = x.OrderDesi,
                CarrierId = x.CarrierId,
                CarrierName = x.Carrier.CarrierName
            }).ToListAsync();

            return PaginationChanger.PaginationDataChange(realResponse, result);
        }
    }
}
