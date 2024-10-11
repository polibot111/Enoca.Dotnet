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

namespace Enoca.ApplicationLayer.Features.CarrierReports.Query.GetAllCarrierReports
{
    public class GetAllQueryCarrierReportsHandler : IRequestHandler<GetAllQueryCarrierReportsRequest, IWrapperPaginationResponse<GetAllQueryCarrierReportsResponse>>
    {
        private readonly ICarrierReportsRepository _carrierReportsRepository;
        public GetAllQueryCarrierReportsHandler(ICarrierReportsRepository carrierReportsRepository)
        {
            _carrierReportsRepository = carrierReportsRepository;
        }
        public async Task<IWrapperPaginationResponse<GetAllQueryCarrierReportsResponse>> Handle(GetAllQueryCarrierReportsRequest request, CancellationToken cancellationToken)
        {
            var response = await _carrierReportsRepository.GetAllQuerablePagedReponseAsync(request);

            var realResponse = await response.Data.Select(x => new GetAllQueryCarrierReportsResponse()
            {
                Id = x.Id,
                CarrierCost = x.CarrierCost,
                CarrierReportDate = x.CarrierReportDate,
                CarriersId = x.CarriersId,
                CarriersName = x.Carriers.CarrierName
            }).ToListAsync();

            return PaginationChanger.PaginationDataChange(realResponse, response);
        }
    }
}
