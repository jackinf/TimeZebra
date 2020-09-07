using EventFlow.ValueObjects;

namespace TimeZebra.TimeManagement.Domain
{
    public class TimeRecord : ValueObject
    {
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public string Notes { get; set; }
        public int FromSeconds { get; set; }
        public int ToSeconds { get; set; }
    }
}