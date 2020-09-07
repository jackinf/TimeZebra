using System;
using Nest;

namespace TimeZebra.TimeManagement.ReadModel.ElasticSearch.TimeManagement
{
    public class TimeRecord
    {
        [Keyword]
        public Guid Id { get; set; }
        
        [Text]
        public string CustomerName { get; set; }
        
        [Text]
        public string ProjectName { get; set; }
        
        [Text]
        public string TaskName { get; set; }
        
        [Text]
        public string Notes { get; set; }
        
        [Number(NumberType.Integer)]
        public int FromSeconds { get; set; }
        
        [Number(NumberType.Integer)]
        public int ToSeconds { get; set; }
    }
    
    public static class TimeRecordMapper
    {
        public static TimeRecord ToReadModel(this Domain.TimeRecord timeRecord) => new TimeRecord
        {
            Id = Guid.NewGuid(),
            CustomerName = timeRecord.CustomerName,
            ProjectName = timeRecord.ProjectName,
            TaskName = timeRecord.TaskName,
            Notes = timeRecord.Notes,
            FromSeconds = timeRecord.FromSeconds,
            ToSeconds = timeRecord.ToSeconds
        };
    }
}