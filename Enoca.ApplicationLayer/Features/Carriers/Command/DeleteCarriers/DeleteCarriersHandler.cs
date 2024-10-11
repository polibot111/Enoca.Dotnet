using Enoca.ApplicationLayer.Exceptions;
using Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.DeleteCarrierConfigurations;
using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.Carriers.Command.DeleteCarriers
{
    public class DeleteCarriersHandler : IRequestHandler<DeleteCarriersRequest, IResponse>
    {
        private readonly ICarriersRepository _carriersRepository;
        private IMediator _mediator;
        public DeleteCarriersHandler(ICarriersRepository carriersRepository, IMediator mediator)
        {
            _carriersRepository = carriersRepository;
            _mediator = mediator;
        }
        public async Task<IResponse> Handle(DeleteCarriersRequest request, CancellationToken cancellationToken)
        {
            var entity = await _carriersRepository.GetByIdIncludeAsync(request.Id, include: x=>x.Include(x => x.CarrierConfigurations));

            if (entity == null)
            {
                throw new BusinessException("Kargo Firmasi bulunamadi.");
            }

            var result = await _carriersRepository.UpdateIsDeletedAsync(entity);
        

            foreach (var item in entity.CarrierConfigurations)
            {

                DeleteCarrierConfigurationsRequest deleteCarrierConfigurationRequest = new DeleteCarrierConfigurationsRequest()
                {
                    Id = item.Id,
                    SavaChanges = false
                };

                await _mediator.Send(deleteCarrierConfigurationRequest);

            }


            if (request.SavaChanges)
                await _carriersRepository.SaveAsync();


            return ResponseFactory.CreateResponse(result);
        }
    }
}
