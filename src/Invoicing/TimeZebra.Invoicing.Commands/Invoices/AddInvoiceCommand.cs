using EventFlow.Commands;
using TimeZebra.Invoicing.Domain;

namespace TimeZebra.Invoicing.Commands.Invoices
{
    public class AddInvoiceCommand : Command<InvoiceAggregate, InvoiceId>
    {
        public string Title { get; }

        public AddInvoiceCommand(InvoiceId aggregateId, string title) : base(aggregateId)
        {
            Title = title;
        }
    }
}