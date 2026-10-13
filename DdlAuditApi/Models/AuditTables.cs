using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DdlAuditApi.Models
{
    [Table("Audit_Tables")]
    public class AuditTables
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuditID { get; set; }

        public DateTime? EventTime { get; set; }

        [StringLength(50)]
        public string? EventType { get; set; }

        [StringLength(128)]
        public string? DatabaseName { get; set; }

        [StringLength(128)]
        public string? SchemaName { get; set; }

        [StringLength(128)]
        public string? TableName { get; set; }

        [StringLength(128)]
        public string? UserName { get; set; }

        [StringLength(128)]
        public string? HostName { get; set; }

        [StringLength(128)]
        public string? AppName { get; set; }

        // Length -1 corresponds to nvarchar(max)
        public string? TSQLCommand { get; set; }
    }


}