using EventFlow.Aggregates;
using TimeZebra.Invoices.Domain.Invoices.Events;

namespace TimeZebra.Invoices.Domain
{
    public class InvoiceAggregateState : AggregateState<InvoiceAggregate, InvoiceId, InvoiceAggregateState>,
        IApply<InvoiceCreatedEvent>
    {
        public string InvoiceTitle { get; set; }
        
        public void Apply(InvoiceCreatedEvent aggregateEvent)
        {
            InvoiceTitle = aggregateEvent.Title;
        }
    }
}