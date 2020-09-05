using System;
using EventFlow;
using EventFlow.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TimeZebra.Invoices.Api.HealthCheck;
using TimeZebra.Invoices.Api.Swagger;
using TimeZebra.Invoices.CommandHandlers;
using TimeZebra.Invoices.Commands;
using TimeZebra.Invoices.Domain;

namespace TimeZebra.Invoices.Api
{
    public static class ApplicationBootstrap
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterCommonServices(services);
            RegisterEventFlow(services);
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
                // .RegisterModule<EntityFrameworkQueryHandlersModule>()
                // .RegisterModule<EntityFrameworkEventStoreModule>()
                // .RegisterModule<EntityFrameworkReadModelModule>();
                
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