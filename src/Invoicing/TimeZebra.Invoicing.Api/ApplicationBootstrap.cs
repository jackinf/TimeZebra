using System;
using EventFlow;
using EventFlow.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TimeZebra.Invoicing.Api.HealthCheck;
using TimeZebra.Invoicing.Api.Swagger;
using TimeZebra.Invoicing.CommandHandlers;
using TimeZebra.Invoicing.Commands;
using TimeZebra.Invoicing.Domain;
using TimeZebra.Invoicing.QueryHandlers.EntityFramework;
using TimeZebra.Invoicing.ReadModel.EntityFramework;
using TimeZebra.Invoicing.ReadModel.EntityFramework.DBContext;

namespace TimeZebra.Invoicing.Api
{
    public static class ApplicationBootstrap
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterCommonServices(services);
            RegisterEventFlow(services);
            
            // We need this in order for dotnet ef migrations to work
            services.AddDbContext<RestInvoiceReadModelContext>(x =>
                x.UseSqlServer(configuration.GetConnectionString("ReadModelConnectionString")));
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