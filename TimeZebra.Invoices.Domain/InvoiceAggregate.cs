using EventFlow.Aggregates;
using TimeZebra.Invoices.Domain.Invoices.Events;

namespace TimeZebra.Invoices.Domain
{
    public class InvoiceAggregate : AggregateRoot<InvoiceAggregate, InvoiceId>
    {
        private readonly InvoiceAggregateState _state = new InvoiceAggregateState();

        public InvoiceAggregate(InvoiceId id) : base(id)
        {
            Register(_state);
        }

        public void AddInvoice(string title)
        {
            Emit(new InvoiceCreatedEvent(title));
        }
    }
}