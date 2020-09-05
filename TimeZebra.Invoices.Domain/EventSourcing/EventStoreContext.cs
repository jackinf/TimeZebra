using EventFlow.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace TimeZebra.Invoices.Domain.EventSourcing
{
    public class EventStoreContext : DbContext
    {
        public EventStoreContext(DbContextOptions<EventStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .AddEventFlowEvents()
                .AddEventFlowSnapshots();
        }
    }
}