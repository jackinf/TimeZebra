using System;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using TimeZebra.TimeManagement.Commands;
using TimeZebra.TimeManagement.Domain;

namespace TimeZebra.TimeManagement.CommandHandlers
{
    // ReSharper disable once UnusedType.Global
    public class TimeRecordCommandHandler : CommandHandler<TimeManagementAggregate, TimeManagementId, AddTimeRecord>
    {
        public override Task ExecuteAsync(TimeManagementAggregate aggregate, AddTimeRecord command, CancellationToken cancellationToken)
        {
            aggregate.AddTimeRecord(new TimeRecord
            {
                CustomerName = GetCustomerName(command.CustomerId), // TODO: how to convert id to value?
                ProjectName = GetProjectName(command.ProjectId), // TODO: how to convert id to value?
                TaskName = GetTaskName(command.TaskId), // TODO: how to convert id to value?
                Notes = command.Notes,
                FromSeconds = command.FromSeconds,
                ToSeconds = command.ToSeconds
            });

            return Task.CompletedTask;
        }

        private string GetCustomerName(string customerId) => Guid.NewGuid().ToString();
        private string GetProjectName(string projectId) => Guid.NewGuid().ToString();
        private string GetTaskName(string taskId) => Guid.NewGuid().ToString();
    }
}