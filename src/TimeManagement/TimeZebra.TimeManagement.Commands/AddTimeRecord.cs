using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using TimeZebra.TimeManagement.Domain;

namespace TimeZebra.TimeManagement.Commands
{
    public class AddTimeRecord : Command<TimeManagementAggregate, TimeManagementId, IExecutionResult>
    {
        public string CustomerId { get; }
        public string ProjectId { get; }
        public string TaskId { get; }
        public string Notes { get; }
        public int FromSeconds { get; }
        public int ToSeconds { get; }

        public AddTimeRecord(TimeManagementId aggregateId, string customerId, string projectId, string taskId, string notes, in int fromSeconds, in int toSeconds) : base(aggregateId)
        {
            CustomerId = customerId;
            ProjectId = projectId;
            TaskId = taskId;
            Notes = notes;
            FromSeconds = fromSeconds;
            ToSeconds = toSeconds;
        }
    }
}