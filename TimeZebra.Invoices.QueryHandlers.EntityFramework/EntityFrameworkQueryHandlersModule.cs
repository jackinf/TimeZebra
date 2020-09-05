using EventFlow;
using EventFlow.Configuration;
using EventFlow.Extensions;

namespace TimeZebra.Invoices.QueryHandlers.EntityFramework
{
    public class EntityFrameworkQueryHandlersModule : IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions.AddDefaults(typeof(EntityFrameworkQueryHandlersModule).Assembly);
        }
    }
}