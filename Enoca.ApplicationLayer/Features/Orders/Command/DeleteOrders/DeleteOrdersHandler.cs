using Enoca.ApplicationLayer.Exceptions;
using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Orders.Command.DeleteOrders
{
    public class DeleteOrdersHandler : IRequestHandler<DeleteOrdersRequest, IResponse>
    {
        private readonly IOrdersRepository _ordersRepository;

        public DeleteOrdersHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<IResponse> Handle(DeleteOrdersRequest request, CancellationToken cancellationToken)
        {
            var entity = await _ordersRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new BusinessException("Siparis bulunamadi.");
            }

            var result = await _ordersRepository.UpdateIsDeletedAsync(entity);

            if (request.SavaChanges)
                await _ordersRepository.SaveAsync();

            return ResponseFactory.CreateResponse(result);
        }
    }
}
