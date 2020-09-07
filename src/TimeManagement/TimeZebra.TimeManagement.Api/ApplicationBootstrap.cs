using EventFlow;
using EventFlow.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TimeZebra.TimeManagement.Api.HealthCheck;
using TimeZebra.TimeManagement.CommandHandlers;
using TimeZebra.TimeManagement.Commands;
using TimeZebra.TimeManagement.Domain;
using TimeZebra.TimeManagement.ReadModel.ElasticSearch;

namespace TimeZebra.TimeManagement.Api
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
        }

        public static void RegisterEventFlow(IServiceCollection services)
        {
            EventFlowOptions.New
                .UseServiceCollection(services) // ??
                .RegisterModule<DomainModule>()
                .RegisterModule<CommandModule>()
                .RegisterModule<CommandHandlersModule>()

                .RegisterModule<DomainModule>()
                .RegisterModule<ElasticsearchReadModelModule>()
                // .RegisterModule<MongoDbQueryHandlersModule>() // TODO: implement this
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