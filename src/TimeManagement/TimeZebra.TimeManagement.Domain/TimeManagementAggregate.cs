using EventFlow.Aggregates;
using TimeZebra.TimeManagement.Domain.Events;

namespace TimeZebra.TimeManagement.Domain
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class TimeManagementAggregate : AggregateRoot<TimeManagementAggregate, TimeManagementId>
    {
        private readonly TimeManagementAggregateState _state = new TimeManagementAggregateState();

        public TimeManagementAggregate(TimeManagementId id) : base(id) => Register(_state);

        public void AddTimeRecord(TimeRecord timeRecord) => Emit(new TimeRecordAdded(timeRecord));
    }
}