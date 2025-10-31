namespace _291025_NVE.CQRS.Model
{
    public class UserAdditionalInfo(string ip, string userAgent)
    {
        public string IP_Address { get; set; } = ip;
        public string UserAgent { get; set; } = userAgent;
        public DateTime Command_Execute_Time { get; set; } = DateTime.UtcNow;
    }
}
