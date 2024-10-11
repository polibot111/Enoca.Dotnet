using Hangfire;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Hangfire.Configurations
{
    public static class HangfireBase
    {
        public static void Enqueue<T>(this IMediator mediator, string jobId, IRequest<T> request) where T : class
        {
            //var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget!"));
            var client = new BackgroundJobClient();
            client.Enqueue<Connector>(connector => connector.Send(jobId, request));
        }
        public static void Schedule<T>(this IMediator mediator, string jobId, IRequest<T> request, TimeSpan time) where T : class
        {
            //var jobId = BackgroundJob.Schedule(() => Console.WriteLine("Delayed!"), TimeSpan.FromDays(7));
            var client = new BackgroundJobClient();
            client.Schedule<Connector>(connector => connector.Send(jobId, request), time);
        }
        public static void AddOrUpdate<T>(this IMediator mediator, string jobId, IRequest<T> request, string cron) where T : class
        {
            //RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring!"), Cron.Daily);
            var client = new RecurringJobManager();
            client.AddOrUpdate<Connector>(jobId, connector => connector.Send(jobId, request), cron);
        }
        public static void ContinueJobWith<T>(this IMediator mediator, string jobId, IRequest<T> request) where T : class
        {
            //BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("Continuation!"));
            var client = new BackgroundJobClient();
            client.ContinueJobWith<Connector>(jobId, connector => connector.Send(jobId, request));
        }

    }
}
