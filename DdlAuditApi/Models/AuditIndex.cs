namespace DdlAuditApi.Models
{
    public class AuditIndex
    {
        public int AuditID { get; set; }
        public DateTime EventTime { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string SchemaName { get; set; } = string.Empty;
        public string ObjectName { get; set; } = string.Empty;
        public string IndexName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string HostName { get; set; } = string.Empty;
        public string AppName { get; set; } = string.Empty;
        public string TSQLCommand { get; set; } = string.Empty;
    }

}