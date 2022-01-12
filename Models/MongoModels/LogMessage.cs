
using Newtonsoft.Json;
using System;

namespace UIBlazor.Models.MongoModels
{
    public class LogMessage : BaseModel, IComparable<LogMessage>
    {
        
        public string Id { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string DateOrTime { get; set; }
        public string Iniciator { get; set; }

        private DateTime? ConvertStringDate()
        {
            DateTime? date = DateTime.TryParse(DateOrTime, out _) ? Convert.ToDateTime(DateOrTime) : null;
            return date;
        }

        public int CompareTo(LogMessage other)
        {
            if (ConvertStringDate() > other.ConvertStringDate()) return 1;
            if (ConvertStringDate() < other.ConvertStringDate()) return -1;
            return 0;
        }
    }
}