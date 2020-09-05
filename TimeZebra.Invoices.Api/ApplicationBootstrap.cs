using System;
using EventFlow;
using EventFlow.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TimeZebra.Invoices.Api.HealthCheck;
using TimeZebra.Invoices.Api.Swagger;
using TimeZebra.Invoices.CommandHandlers;
using TimeZebra.Invoices.Commands;
using TimeZebra.Invoices.Domain;
using TimeZebra.Invoices.QueryHandlers.EntityFramework;
using TimeZebra.Invoices.ReadModel.EntityFramework;
using TimeZebra.Invoices.ReadModel.EntityFramework.DBContext;

namespace TimeZebra.Invoices.Api
{
    public static class ApplicationBootstrap
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterCommonServices(services);
            RegisterEventFlow(services);
            
            // We need this in order for dotnet ef migrations to work
            services.AddDbContext<RestInvoiceReadModelContext>(x =>
                x.UseSqlServer("ReadModelConnectionString"));
        }

        public static void RegisterCommonServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            RegisterHealthCheck(services);
            SwaggerServicesConfiguration.Confirure(services);
        }

        public static void RegisterEventFlow(IServiceCollection services)
        {
            EventFlowOptions.New
                .UseServiceCollection(services) // ??
                .RegisterModule<DomainModule>()
                .RegisterModule<CommandModule>()
                .RegisterModule<CommandHandlersModule>()
                
                // TODO: uncommnent
                .RegisterModule<EntityFrameworkQueryHandlersModule>()
                .RegisterModule<EntityFrameworkEventStoreModule>()
                .RegisterModule<EntityFrameworkReadModelModule>();
                
                // MongoDB event store and read model
                // .RegisterModule<MongoDBEventStoreModule>()
                // .RegisterModule<MongoDbReadModelModule>()
                // .RegisterModule<MongoDbQueryHandlersModule>()
                ;
        }
        
        private static void RegisterHealthCheck(IServiceCollection services)
        {
            services.AddSingleton<StartupHostedServiceHealthCheck>();

            services.AddHealthChecks()
                .AddCheck<StartupHostedServiceHealthCheck>(
                    "hosted_service_startup",
                    failureStatus: HealthStatus.Degraded,
                    tags: new[] {"ready"});
        }
    }
}