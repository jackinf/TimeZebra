using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using TimeZebra.Invoicing.Domain.EventSourcing;

namespace TimeZebra.Invoicing.Domain
{
    public class EntityFrameworkEventStoreModule : IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions
                .ConfigureEntityFramework(EntityFrameworkConfiguration.New)
                .AddDbContextProvider<EventStoreContext, EventStoreContextProvider>()
                .UseEntityFrameworkEventStore<EventStoreContext>()
                .UseEntityFrameworkSnapshotStore<EventStoreContext>();
        }
    }
}