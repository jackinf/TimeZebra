using System.Collections.Generic;
using EventFlow.Aggregates;
using TimeZebra.TimeManagement.Domain.Events;

namespace TimeZebra.TimeManagement.Domain
{
    public class TimeManagementAggregateState : 
        AggregateState<TimeManagementAggregate, TimeManagementId, TimeManagementAggregateState>,
        IApply<TimeRecordAdded>
    {
        public IReadOnlyList<TimeRecord> TimeRecords => _timeRecords.AsReadOnly();
        
        private readonly List<TimeRecord> _timeRecords = new List<TimeRecord>();
        
        public void Apply(TimeRecordAdded aggregateEvent) => _timeRecords.Add(aggregateEvent.Value);
    }
}