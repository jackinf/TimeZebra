using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using TimeZebra.Invoices.Commands.Invoices;
using TimeZebra.Invoices.Domain;

namespace TimeZebra.Invoices.CommandHandlers
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