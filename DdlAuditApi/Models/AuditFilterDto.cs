namespace DdlAuditApi.Models
{

    public class AuditFilterDto
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? EventType { get; set; }
        public string? ObjectName { get; set; }
        public string? UserName { get; set; }
    }
}
