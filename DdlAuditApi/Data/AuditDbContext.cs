using DdlAuditApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DdlAuditApi.Data
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options) { }

        public DbSet<AuditIndex> Audit_Indexes { get; set; }
        public DbSet<AuditTables> Audit_Tables { get; set; }
        public DbSet<AuditTables> AuditTables { get; set; } // <--- EF defaults to using "AuditTables"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditIndex>().HasKey(e => e.AuditID);
            modelBuilder.Entity<AuditIndex>().ToTable("Audit_Indexes", "dbo");
            modelBuilder.Entity<AuditTables>().ToTable("Audit_Tables", "dbo");

        }
    }
}