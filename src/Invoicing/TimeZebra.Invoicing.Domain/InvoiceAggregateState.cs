using EventFlow.Aggregates;
using TimeZebra.Invoicing.Domain.Invoices.Events;

namespace TimeZebra.Invoicing.Domain
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