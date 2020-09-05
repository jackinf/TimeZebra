using EventFlow.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace TimeZebra.Invoices.Domain.EventSourcing
{
    public class EventStoreContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .AddEventFlowEvents()
                .AddEventFlowSnapshots();
        }
    }
}