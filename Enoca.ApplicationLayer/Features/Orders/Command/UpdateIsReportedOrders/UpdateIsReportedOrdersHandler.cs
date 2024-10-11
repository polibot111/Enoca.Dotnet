using Enoca.ApplicationLayer.Exceptions;
using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Orders.Command.UpdateIsReportedOrders
{
    public class UpdateIsReportedOrdersHandler : IRequestHandler<UpdateIsReportedOrdersRequest, IResponse>
    {
        private readonly IOrdersRepository _ordersRepository;

        public UpdateIsReportedOrdersHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<IResponse> Handle(UpdateIsReportedOrdersRequest request, CancellationToken cancellationToken)
        {
            var entity = await _ordersRepository.GetByIdAsync(request.Id);

            if (entity == null) 
            {
                throw new BusinessException("Siparis bulunamadi.");
            }

            entity.IsReported = true;

            var response = await _ordersRepository.UpdateAsync(entity);

            return ResponseFactory.CreateResponse(response);

        }
    }
}
