using System;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using Microsoft.AspNetCore.Mvc;
using TimeZebra.Invoices.Api.Resources.Invoices.Add;
using TimeZebra.Invoices.Commands.Invoices;
using TimeZebra.Invoices.Domain;

namespace TimeZebra.Invoices.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public InvoiceController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddInvoice(string invoiceId, [FromBody] AddInvoiceViewModel addInvoiceViewModel)
        {
            var command = new AddInvoiceCommand(InvoiceId.With(Guid.Parse(invoiceId)), addInvoiceViewModel.Title);
            await _commandBus.PublishAsync(command, CancellationToken.None);
            return Ok();
        }
    }
}