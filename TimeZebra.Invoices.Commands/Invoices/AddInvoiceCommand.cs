using EventFlow.Commands;
using TimeZebra.Invoices.Domain;

namespace TimeZebra.Invoices.Commands.Invoices
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