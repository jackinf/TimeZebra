using System;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.EntityFramework;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TimeZebra.Invoicing.Domain.EventSourcing;
using TimeZebra.Invoicing.ReadModel.EntityFramework.DBContext;

namespace TimeZebra.Invoicing.Api.HealthCheck
{
    public class StartupHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private readonly StartupHostedServiceHealthCheck _startupHostedServiceHealthCheck;
        private readonly IDbContextProvider<EventStoreContext> _eventStoreContextProvider;
        private readonly IDbContextProvider<RestInvoiceReadModelContext> _readModelContextProvider;

        public StartupHostedService(ILogger logger,
            StartupHostedServiceHealthCheck startupHostedServiceHealthCheck,
            IDbContextProvider<EventStoreContext> eventStoreContextProvider,
            IDbContextProvider<RestInvoiceReadModelContext> readModelContextProvider)
        {
            _logger = logger;
            _startupHostedServiceHealthCheck = startupHostedServiceHealthCheck;
            _eventStoreContextProvider = eventStoreContextProvider;
            _readModelContextProvider = readModelContextProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Start preparing downstream infrastructure");

            Task.Run(() =>
            {
                _eventStoreContextProvider.CreateContext();
                _readModelContextProvider.CreateContext();

                _startupHostedServiceHealthCheck.StartupTaskCompleted = true;

                _logger.LogInformation($"Downstream infrastructure is ready");
            }, cancellationToken);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("End preparing downstream infrastructure");

            return Task.CompletedTask;
        }

        public void Dispose()
        {
        }
    }
}