using EventFlow;
using EventFlow.Configuration;
using EventFlow.Extensions;

namespace TimeZebra.TimeManagement.CommandHandlers
{
    public class CommandHandlersModule : IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions.AddDefaults(typeof(CommandHandlersModule).Assembly);
        }
    }
}