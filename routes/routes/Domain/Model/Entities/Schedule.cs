namespace Frock_backend.routes.Domain.Model.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string DayOfWeek { get; set; }
        public bool Enabled { get; set; }

        public Schedule(string startTime, string endTime, string dayOfWeek, bool enabled)
        {
            StartTime = startTime;
            EndTime = endTime;
            DayOfWeek = dayOfWeek;
            Enabled = enabled;
        }
    }
}