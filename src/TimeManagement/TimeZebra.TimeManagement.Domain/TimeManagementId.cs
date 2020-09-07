using EventFlow.Core;

namespace TimeZebra.TimeManagement.Domain
{
    public class TimeManagementId : Identity<TimeManagementId>
    {
        public TimeManagementId(string value) : base(value)
        {
        }
    }
}