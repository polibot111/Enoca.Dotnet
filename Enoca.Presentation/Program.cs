using Enoca.ApplicationLayer;
using Enoca.ApplicationLayer.Hangfire.Configurations;
using Enoca.ApplicationLayer.Hangfire.HangfireAuthorizationFilter;
using Enoca.ApplicationLayer.Hangfire.Services;
using Enoca.ApplicationLayer.Interface.Hangfire.Connection;
using Enoca.ApplicationLayer.Validations.Orders;
using Enoca.Infrastructure;
using Enoca.Persistance;
using Enoca.Persistance.Context;
using Enoca.Presentation.Middlewares;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.MediatR;
using Hangfire.SqlServer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateOrdersRequestValidation>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationLayerServices();
builder.Services.AddInfrastructureServices();



builder.Services.AddHangfire(configuration => configuration
          .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(builder.Configuration.GetConnectionString("DatabaseConnectionHangfire"), new SqlServerStorageOptions
          {
              CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
              SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
              QueuePollInterval = TimeSpan.Zero,
              UseRecommendedIsolationLevel = true,
              DisableGlobalLocks = true
          })
          .UseMediatR());


builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var dbContext = serviceProvider.GetRequiredService<MyDbContext>();
    dbContext.Database.Migrate();

    var serviceProviderHangfire = scope.ServiceProvider;
    var hangfire = serviceProvider.GetRequiredService<IHangfireConnection>();
    hangfire.EnsureHangfireDatabaseExists(builder.Configuration.GetConnectionString("DatabaseConnectionHangfire"));
}



using (var scope = app.Services.CreateScope())
{
    var hangService = scope.ServiceProvider.GetRequiredService<IHangService>();
    await hangService.Fire();
}

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() }
});

app.Run();
