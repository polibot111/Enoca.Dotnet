using Enoca.ApplicationLayer.Interface.Hangfire.Connection;
using Enoca.ApplicationLayer.Interface.Repositories.Services;
using Enoca.Persistance.Context;
using Enoca.Persistance.Hangfire;
using Enoca.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Enoca.Persistance
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DatabaseConnection");


            services.AddDbContext<MyDbContext>((sp, options) =>
            {
                options.UseSqlServer(connection);
            });

            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<ICarriersRepository, CarriersRepository>();
            services.AddScoped<ICarrierConfigurationsRepository, CarrierConfigurationsRepository>();
            services.AddScoped<ICarrierReportsRepository, CarrierReportsRepository>();
            services.AddScoped<IHangfireConnection, HangfireConnection>();

        }
    }
}
