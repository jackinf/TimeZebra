using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TimeZebra.TimeManagement.Api.HealthCheck
{
    public class StartupHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private readonly StartupHostedServiceHealthCheck _startupHostedServiceHealthCheck;

        public StartupHostedService(ILogger logger, StartupHostedServiceHealthCheck startupHostedServiceHealthCheck)
        {
            _logger = logger;
            _startupHostedServiceHealthCheck = startupHostedServiceHealthCheck;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Start preparing downstream infrastructure");

            Task.Run(() =>
            {
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