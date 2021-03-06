using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using EventFlow.Extensions;
using TimeZebra.Invoicing.ReadModel.EntityFramework.DBContext;

namespace TimeZebra.Invoicing.ReadModel.EntityFramework
{
    public class EntityFrameworkReadModelModule: IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions
                .ConfigureEntityFramework(EntityFrameworkConfiguration.New)
                .AddDefaults(typeof(EntityFrameworkReadModelModule).Assembly)
                .AddDbContextProvider<RestInvoiceReadModelContext, RestInvoiceReadModelDbContextProvider>()
                .UseEntityFrameworkReadModel<InvoiceReadModel, RestInvoiceReadModelContext>();
        }
    }
}