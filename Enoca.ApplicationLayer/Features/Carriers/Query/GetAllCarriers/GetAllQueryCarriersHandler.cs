using Enoca.ApplicationLayer.Commons;
using Enoca.ApplicationLayer.Features.CarrierConfigurations.Query.GetAllCarrierConfigurations;
using Enoca.ApplicationLayer.Features.Orders.Query.GetAllOrder;
using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Carriers.Query.GetAllCarriers
{
    public class GetAllQueryCarriersHandler : IRequestHandler<GetAllQueryCarriersRequest, IWrapperPaginationResponse<GetAllQueryCarriersResponse>>
    {
        private readonly ICarriersRepository _carriersRepository;

        public GetAllQueryCarriersHandler(ICarriersRepository carriersRepository)
        {
            _carriersRepository = carriersRepository;
        }

        public async Task<IWrapperPaginationResponse<GetAllQueryCarriersResponse>> Handle(GetAllQueryCarriersRequest request, CancellationToken cancellationToken)
        {

            var result = await _carriersRepository.GetAllQuerablePagedReponseAsync(request);

            var realResponse = await result.Data.Select(x => new GetAllQueryCarriersResponse()
            {
                Id = x.Id,
                CarrierIsActive = x.CarrierIsActive,
                CarrierName = x.CarrierName,
                CarrierPlusDesiCost = x.CarrierPlusDesiCost,
                Orders = x.Order.Select(y => new GetAllOrdersQueryResponse()
                {
                    Id = y.Id,
                    OrderCarrierCost = y.OrderCarrierCost,
                    OrderDate = y.OrderDate,
                    OrderDesi = y.OrderDesi,
                    CarrierId = y.CarrierId,
                    CarrierName = y.Carrier.CarrierName
                }).ToList(),
                CarrierConfigurations = x.CarrierConfigurations.Select(z => new GetAllQueryCarrierConfigurationsResponse()
                {
                    Id = z.Id,
                    CarrierCost = z.CarrierCost,
                    CarrierMaxDesi = z.CarrierMaxDesi,
                    CarrierMinDesi = z.CarrierMinDesi,
                    CarrierId = z.CarrierId,
                    CarrierName = z.Carrier.CarrierName
                }).ToList()

            }).ToListAsync();

            return PaginationChanger.PaginationDataChange(realResponse, result);
        }


    }

}
