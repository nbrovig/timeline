using System.ComponentModel.DataAnnotations.Schema;

namespace timeline.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Ingress { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime Time { get; set; }
        public string DisplayTime { get; set; } = string.Empty;
        public string PersonCodes { get; set; } = string.Empty;
    }
}