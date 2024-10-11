using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Orders.Command.CreateOrders
{
    public class CreateOrdersHandler : IRequestHandler<CreateOrdersRequest, IResponse>
    {
        private readonly ICarrierConfigurationsRepository _carrierConfigurationsRepository;
        private readonly ICarriersRepository _carriersRepository;
        private readonly IOrdersRepository _ordersRepository;

        public CreateOrdersHandler(IOrdersRepository ordersRepository, ICarriersRepository carriersRepository, ICarrierConfigurationsRepository carrierConfigurationsRepository)
        {
            _ordersRepository = ordersRepository;
            _carriersRepository = carriersRepository;
            _carrierConfigurationsRepository = carrierConfigurationsRepository;
        }

        public async Task<IResponse> Handle(CreateOrdersRequest request, CancellationToken cancellationToken)
        {
            Core.Entities.Orders response = new();


            var matchingConfigurations = (await _carrierConfigurationsRepository.GetAllAsync(cc => cc.CarrierMinDesi <= request.OrderDesi && cc.CarrierMaxDesi >= request.OrderDesi, tracking: false)).ToList();

            if (matchingConfigurations.Any())
            {

                var carrierWithLowestCost = matchingConfigurations.OrderBy(cc => cc.CarrierCost).First();

                response = await _ordersRepository.AddAsync(new Core.Entities.Orders()
                {
                    OrderDate = DateTime.UtcNow,
                    OrderDesi = request.OrderDesi,
                    OrderCarrierCost = carrierWithLowestCost.CarrierCost,
                    CarrierId = carrierWithLowestCost.CarrierId
                });
            }
            else
            {

                var allConfigurations = (await _carrierConfigurationsRepository.GetAllAsync()).ToList();

                var closestConfiguration = allConfigurations
                    .Select(cc => new
                    {
                        Configuration = cc,
                        Difference = Math.Min(
                            Math.Abs(request.OrderDesi - cc.CarrierMinDesi),
                            Math.Abs(request.OrderDesi - cc.CarrierMaxDesi))
                    })
                    .OrderBy(x => x.Difference)
                    .ThenBy(x => x.Configuration.CarrierCost)
                    .First().Configuration;

                var overValued = request.OrderDesi - closestConfiguration.CarrierMaxDesi;

                var cost = closestConfiguration.CarrierCost + ((overValued + 1 ) * overValued);

                response = await _ordersRepository.AddAsync(new Core.Entities.Orders()
                {
                    OrderDate = DateTime.UtcNow,
                    OrderDesi = request.OrderDesi,
                    OrderCarrierCost = cost,
                    CarrierId = closestConfiguration.CarrierId
                });
            }

            await _ordersRepository.SaveAsync();

            return ResponseFactory.CreateResponse(response);

        }
    }
}
