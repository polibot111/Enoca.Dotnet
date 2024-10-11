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

namespace Enoca.ApplicationLayer.Features.Carriers.Command.CreateCarriers
{
    public class CreateCarriersHandler : IRequestHandler<CreateCarriersRequest, IResponse>
    {
        private readonly ICarriersRepository _carriersRepository;
        private IMapper _mapper;

        public CreateCarriersHandler(ICarriersRepository carriersRepository, IMapper mapper)
        {
            _carriersRepository = carriersRepository;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(CreateCarriersRequest request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<Core.Entities.Carriers>(request);

            var result = await _carriersRepository.AddAsync(entity);

            await _carriersRepository.SaveAsync();

            return ResponseFactory.CreateResponse(result);
        }
    }
}
