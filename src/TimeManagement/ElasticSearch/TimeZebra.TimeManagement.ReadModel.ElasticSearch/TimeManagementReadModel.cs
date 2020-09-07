using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.ReadStores;
using Nest;
using TimeZebra.TimeManagement.Domain;
using TimeZebra.TimeManagement.Domain.Events;
using TimeZebra.TimeManagement.ReadModel.ElasticSearch.TimeManagement;

namespace TimeZebra.TimeManagement.ReadModel.ElasticSearch
{
    [ElasticsearchType(IdProperty = "Id", Name = "timemanagement")]
    public class TimeManagementReadModel : IReadModel,
        IAmReadModelFor<TimeManagementAggregate, TimeManagementId, TimeRecordAdded>
    {
        public TimeManagementReadModel()
        {
            TimeRecords = new List<TimeManagement.TimeRecord>();
        }
        
        [Keyword] 
        [PropertyName("_id")]
        public string Id { get; protected set; }

        [Nested] 
        public List<TimeManagement.TimeRecord> TimeRecords { get; set; }
        
        public void Apply(IReadModelContext context, IDomainEvent<TimeManagementAggregate, TimeManagementId, TimeRecordAdded> domainEvent) 
            => TimeRecords.Add(domainEvent.AggregateEvent.Value.ToReadModel());
    }
}