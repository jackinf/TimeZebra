using EventFlow;
using EventFlow.Configuration;
using EventFlow.Extensions;
using EventFlow.AspNetCore.Extensions;

namespace TimeZebra.Invoices.Domain
{
    public class DomainModule : IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions
                .AddDefaults(typeof(DomainModule).Assembly)
                .AddAspNetCore();
        }
    }
}