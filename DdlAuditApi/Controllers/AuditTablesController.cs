using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DdlAuditApi.Data;
using DdlAuditApi.Models;

namespace DdlAuditApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditTablesController : ControllerBase
    {
        private readonly AuditDbContext _context;

        public AuditTablesController(AuditDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<IActionResult> GetAuditTables([FromQuery] AuditFilterDto? filter)
        {
            filter ??= new AuditFilterDto();

            var query = _context.Audit_Tables.AsNoTracking();

            // 1. Filter by ObjectName / SchemaName safely
            if (!string.IsNullOrWhiteSpace(filter.ObjectName))
            {
                query = query.Where(x => x.SchemaName != null && x.SchemaName.Contains(filter.ObjectName));
            }

            // 2. Filter by EventType
            if (!string.IsNullOrWhiteSpace(filter.EventType))
            {
                query = query.Where(x => x.EventType == filter.EventType);
            }

            // 3. Filter by FromDate (Check HasValue and compare against .Value for Nullable DateTime)
            if (filter.FromDate.HasValue)
            {
                query = query.Where(x => x.EventTime.HasValue && x.EventTime.Value >= filter.FromDate.Value);
            }

            // 4. Filter by ToDate (Check HasValue and compare against .Value for Nullable DateTime)
            if (filter.ToDate.HasValue)
            {
                query = query.Where(x => x.EventTime.HasValue && x.EventTime.Value <= filter.ToDate.Value);
            }

            // 5. OrderByDescending safely with Nullable DateTime
            var result = await query
                .OrderByDescending(x => x.EventTime)
                .Take(500) // Performance safeguard
                .ToListAsync();

            return Ok(result);
        }

        // GET: api/AuditTables/event-types
        [HttpGet("event-types")]
        public async Task<IActionResult> GetEventTypes()
        {
            var types = await _context.Audit_Tables
                .Where(x => x.EventType != null)
                .Select(x => x.EventType)
                .Distinct()
                .ToListAsync();

            return Ok(types);
        }
    }
}