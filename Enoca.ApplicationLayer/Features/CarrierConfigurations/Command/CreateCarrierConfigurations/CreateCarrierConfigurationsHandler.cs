using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.ApplicationLayer.Wrappers;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Features.CarrierConfigurations.Command.CreateCarrierConfigurations
{
    public class CreateCarrierConfigurationsHandler : IRequestHandler<CreateCarrierConfigurationsRequest, IResponse>
    {
        private readonly ICarrierConfigurationsRepository _carrierConfigurationsRepository;
        private IMapper _mapper;

        public CreateCarrierConfigurationsHandler(ICarrierConfigurationsRepository carrierConfigurationsRepository, IMapper mapper)
        {
            _carrierConfigurationsRepository = carrierConfigurationsRepository;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(CreateCarrierConfigurationsRequest request, CancellationToken cancellationToken)
        {
           var entity = _mapper.Map<Core.Entities.CarrierConfigurations>(request);

            entity = await _carrierConfigurationsRepository.AddAsync(entity);

            await _carrierConfigurationsRepository.SaveAsync();

            return ResponseFactory.CreateResponse(entity);
        }
    }
}
