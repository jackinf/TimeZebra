using System;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using Microsoft.AspNetCore.Mvc;
using TimeZebra.Invoicing.Api.Resources.Invoices.Add;
using TimeZebra.Invoicing.Commands.Invoices;
using TimeZebra.Invoicing.Domain;

namespace TimeZebra.Invoicing.Api.Controllers
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
        public async Task<IActionResult> AddInvoice([FromBody] AddInvoiceViewModel addInvoiceViewModel)
        {
            var command = new AddInvoiceCommand(InvoiceId.New, addInvoiceViewModel.Title);
            await _commandBus.PublishAsync(command, CancellationToken.None);
            return Ok();
        }
    }
}