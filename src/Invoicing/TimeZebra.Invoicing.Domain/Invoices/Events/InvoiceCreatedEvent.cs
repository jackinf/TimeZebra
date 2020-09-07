using EventFlow.Aggregates;
using EventFlow.EventStores;

namespace TimeZebra.Invoicing.Domain.Invoices.Events
{
    [EventVersion("InvoiceCreated", 1)]
    public class InvoiceCreatedEvent : AggregateEvent<InvoiceAggregate, InvoiceId>
    {
        public string Title { get; }

        public InvoiceCreatedEvent(string title)
        {
            Title = title;
        }
    }
}