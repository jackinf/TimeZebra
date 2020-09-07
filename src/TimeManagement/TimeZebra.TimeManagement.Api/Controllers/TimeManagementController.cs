using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using Microsoft.AspNetCore.Mvc;
using TimeZebra.TimeManagement.Api.Resources.TimeRecord.Add;
using TimeZebra.TimeManagement.Commands;
using TimeZebra.TimeManagement.Domain;

namespace TimeZebra.TimeManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeManagementController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public TimeManagementController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddTimeRecord([FromBody] AddTimeRecordViewModel addInvoiceViewModel)
        {
            var command = new AddTimeRecord(
                TimeManagementId.New, 
                addInvoiceViewModel.CustomerId,
                addInvoiceViewModel.ProjectId,
                addInvoiceViewModel.TaskId,
                addInvoiceViewModel.Notes,
                addInvoiceViewModel.FromSeconds,
                addInvoiceViewModel.ToSeconds);
            
            await _commandBus.PublishAsync(command, CancellationToken.None);
            return Ok();
        }
    }
}