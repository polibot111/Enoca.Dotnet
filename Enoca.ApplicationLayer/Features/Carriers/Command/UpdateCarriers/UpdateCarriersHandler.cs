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

namespace Enoca.ApplicationLayer.Features.Carriers.Command.UpdateCarriers
{
    public class UpdateCarriersHandler : IRequestHandler<UpdateCarriersRequest, IResponse>
    {
        private readonly ICarriersRepository _carriersRepository;
        private IMapper _mapper;
        public UpdateCarriersHandler(ICarriersRepository carriersRepository, IMapper mapper)
        {
            _carriersRepository = carriersRepository;
            _mapper = mapper;
        }

 
        public async Task<IResponse> Handle(UpdateCarriersRequest request, CancellationToken cancellationToken)
        {
            var entity = await _carriersRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new BusinessException("Kargo Firmasi bulunamadi.");
            }

            entity = _mapper.Map<Core.Entities.Carriers>(request);

            var result = await _carriersRepository.UpdateAsync(entity);

            await _carriersRepository.SaveAsync();

            return ResponseFactory.CreateResponse(result);
        }
    }
}
