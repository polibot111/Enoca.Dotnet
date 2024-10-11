using Enoca.ApplicationLayer.Features.Orders.Command.UpdateIsReportedOrders;
using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.ApplicationLayer.Wrappers;
using Enoca.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.CarrierReports.Command.CreateCarrierReports
{
    public class CreateCarrierReportsHandler : IRequestHandler<CreateCarrierReportsRequest, IResponse>
    {
        private readonly ICarrierReportsRepository _carrierReportsService;
        private readonly ICarriersRepository _carriersRepository;
        private readonly IMediator _mediator;

        public CreateCarrierReportsHandler(ICarrierReportsRepository carrierReportsService, ICarriersRepository carriersRepository, IMediator mediator)
        {
            _carrierReportsService = carrierReportsService;
            _carriersRepository = carriersRepository;
            _mediator = mediator;
        }

        public async Task<IResponse> Handle(CreateCarrierReportsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var carrier = (await _carriersRepository.GetAllIncludeAsync(x => x.Order.Any(x => x.IsReported == false), include: y => y.Include(z => z.Order)));

                foreach (var item in carrier)
                {
                    Core.Entities.CarrierReports carrierReports = new()
                    {
                        CarrierReportDate = DateTime.Now,
                        CarrierCost = item.Order.Where(x => x.IsReported == false).Sum(x => x.OrderCarrierCost),
                        CarriersId = item.Id
                    };

                    carrierReports = await _carrierReportsService.AddAsync(carrierReports);

                    foreach (var orders in item.Order)
                    {
                        await _mediator.Send(new UpdateIsReportedOrdersRequest() { Id = orders.Id });
                    }
                }

                await _carrierReportsService.SaveAsync();

                return ResponseFactory.CreateResponse(true);
            }
            catch (Exception ex)
            {

                throw;
            }
           

        }
    }
}
