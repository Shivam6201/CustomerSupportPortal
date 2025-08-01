namespace SupportPortalAPI.Models
{
    public class CallLog
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CallTime { get; set; }
    }
}
