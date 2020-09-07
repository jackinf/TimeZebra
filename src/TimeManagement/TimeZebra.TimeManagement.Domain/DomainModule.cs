using EventFlow;
using EventFlow.AspNetCore.Extensions;
using EventFlow.Configuration;
using EventFlow.Extensions;

namespace TimeZebra.TimeManagement.Domain
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