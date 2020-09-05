using EventFlow.Aggregates;

namespace TimeZebra.Invoices.Domain
{
    public class InvoiceAggregate : AggregateRoot<InvoiceAggregate, InvoiceId>
    {
        public InvoiceAggregate(InvoiceId id) : base(id)
        {
        }
    }
}