namespace TimeZebra.TimeManagement.Api.Resources.TimeRecord.Add
{
    public class AddTimeRecordViewModel
    {
        public string CustomerId { get; set; }
        public string ProjectId { get; set; }
        public string TaskId { get; set; }
        public string Notes { get; set; }
        public int FromSeconds { get; set; }
        public int ToSeconds { get; set; }
    }
}