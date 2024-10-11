using Enoca.ApplicationLayer.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Behavior
{
    public class SingleExecutionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken);
            Stopwatch stopWatch = new Stopwatch();
            try
            {


                stopWatch.Start();


                var result = await next();

                stopWatch.Stop();

                if (result is IResponse response && response is not null)
                {
                    response.ElipsedTime = stopWatch.Elapsed;
                }

                return result;
            }
            finally
            {
                _semaphore.Release();
                stopWatch.Stop();
            }
        }
    }
}
