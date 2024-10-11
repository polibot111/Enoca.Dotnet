using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Hangfire.Configurations
{
    public class Connector
    {
        private readonly IMediator _mediator;

        public Connector(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Send<T>(string jobId, IRequest<T> request) where T : class
        {
            var result = await _mediator.Send(request);
        }

    }
}
