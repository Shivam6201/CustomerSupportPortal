namespace SupportPortalAPI.Models
{
    public class CallLog
{
    public int Id { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime CallTime { get; set; }
}

}