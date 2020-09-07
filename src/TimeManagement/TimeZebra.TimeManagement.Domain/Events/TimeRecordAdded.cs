using EventFlow.Aggregates;
using EventFlow.EventStores;

namespace TimeZebra.TimeManagement.Domain.Events
{
    [EventVersion("TimeRecordAdded", 1)]
    public class TimeRecordAdded : AggregateEvent<TimeManagementAggregate, TimeManagementId>
    {
        public TimeRecord Value { get; set; }
        
        public TimeRecordAdded(TimeRecord timeRecord)
        {
            Value = timeRecord;
        }

    }
}