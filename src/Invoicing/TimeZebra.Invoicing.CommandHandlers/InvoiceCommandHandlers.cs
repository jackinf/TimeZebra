using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using TimeZebra.Invoicing.Commands.Invoices;
using TimeZebra.Invoicing.Domain;

namespace TimeZebra.Invoicing.CommandHandlers
{
    public class InvoiceCommandHandlers : CommandHandler<InvoiceAggregate, InvoiceId, AddInvoiceCommand>
    {
        public override Task ExecuteAsync(InvoiceAggregate aggregate, AddInvoiceCommand command, CancellationToken cancellationToken)
        {
            aggregate.AddInvoice(command.Title);

            return Task.CompletedTask;
        }
    }
}