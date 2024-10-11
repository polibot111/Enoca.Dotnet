using Enoca.ApplicationLayer.Exceptions;
using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.ApplicationLayer.Wrappers;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.UpdateCarrierConfigurations
{
    public class UpdateCarrierConfigurationsHandler : IRequestHandler<UpdateCarrierConfigurationsRequest, IResponse>
    {
        private readonly ICarrierConfigurationsRepository _carrierConfigurationsRepository;
        private IMapper _mapper;
        public UpdateCarrierConfigurationsHandler(ICarrierConfigurationsRepository carrierConfigurationsRepository, IMapper mapper)
        {
            _carrierConfigurationsRepository = carrierConfigurationsRepository;
            _mapper = mapper;
        }

   
        public async Task<IResponse> Handle(UpdateCarrierConfigurationsRequest request, CancellationToken cancellationToken)
        {
            var entity = await _carrierConfigurationsRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new BusinessException("Kargo Firmasi Konfigürasyonu bulunamadi.");
            }

            entity = _mapper.Map<Core.Entities.CarrierConfigurations>(request);

            var result = await _carrierConfigurationsRepository.UpdateAsync(entity);

            await _carrierConfigurationsRepository.SaveAsync();

            return ResponseFactory.CreateResponse(result);
        }
    }
}
