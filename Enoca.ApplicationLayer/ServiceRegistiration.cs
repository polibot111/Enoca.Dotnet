using Microsoft.Extensions.DependencyInjection;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Enoca.ApplicationLayer.Behavior;
using Enoca.ApplicationLayer.Features.CarrierReports.Command.CreateCarrierReports;
using Enoca.ApplicationLayer.Hangfire.Services;

namespace Enoca.ApplicationLayer
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationLayerServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(
                                 Assembly.GetExecutingAssembly(),
                                 typeof(CreateCarrierReportsRequest).Assembly
                );

            });

            services.AddMapster();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(SingleExecutionBehavior<,>));

            services.AddSingleton<IHangService, HangfireCarrierReport>();

        }
    }
}
