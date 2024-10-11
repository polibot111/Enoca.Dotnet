using Enoca.ApplicationLayer.Commons;
using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.CarrierConfigurations.Query.GetAllCarrierConfigurations
{
    public class GetAllQueryCarrierConfigurationsHandler : IRequestHandler<GetAllQueryCarrierConfigurationsRequest, IWrapperPaginationResponse<GetAllQueryCarrierConfigurationsResponse>>
    {
        private readonly ICarrierConfigurationsRepository _carrierConfigurationRepository;

        public GetAllQueryCarrierConfigurationsHandler(ICarrierConfigurationsRepository carrierConfigurationRepository)
        {
            _carrierConfigurationRepository = carrierConfigurationRepository;
        }

        public async Task<IWrapperPaginationResponse<GetAllQueryCarrierConfigurationsResponse>> Handle(GetAllQueryCarrierConfigurationsRequest request, CancellationToken cancellationToken)
        {
            var result = await _carrierConfigurationRepository.GetAllQuerablePagedReponseAsync(request);

            var realResponse = await result.Data.Select(x => new GetAllQueryCarrierConfigurationsResponse()
            {
                Id = x.Id,
                CarrierCost = x.CarrierCost,
                CarrierMaxDesi = x.CarrierMaxDesi,
                CarrierMinDesi = x.CarrierMinDesi,
                CarrierId = x.CarrierId,
                CarrierName = x.Carrier.CarrierName
            }).ToListAsync();

            return PaginationChanger.PaginationDataChange(realResponse, result);
        }
    }
}
