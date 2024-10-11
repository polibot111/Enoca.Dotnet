using Enoca.ApplicationLayer.Features.CarrierReports.Command.CreateCarrierReports;
using Enoca.ApplicationLayer.Hangfire.Configurations;
using Enoca.Core.CronExpressions;
using Hangfire;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.ApplicationLayer.Hangfire.Services
{
    public class HangfireCarrierReport : IHangService
    {
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly IMediator _mediator;
        public HangfireCarrierReport(IMediator mediator, IRecurringJobManager recurringJobManager)
        {
            _mediator = mediator;
            _recurringJobManager = recurringJobManager;
        }
        public async Task Fire()
        {
            var jobId = "Reporter";
            _recurringJobManager.AddOrUpdate(
            jobId,
            () => _mediator.Send(new CreateCarrierReportsRequest(), CancellationToken.None),
            CronExpression.EveryHoursOf(1));

        }
    }
}
