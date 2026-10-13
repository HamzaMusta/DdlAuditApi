using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DdlAuditApi.Data;
using DdlAuditApi.Models;

namespace DdlAuditApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditIndexesController : ControllerBase
    {
        private readonly AuditDbContext _context;

        public AuditIndexesController(AuditDbContext context)
        {
            _context = context;
        }

        // GET: api/AuditIndexes
        [HttpGet]
        public async Task<IActionResult> GetAuditIndexes([FromQuery] AuditFilterDto filter)
        {
            var query = _context.Audit_Indexes.AsQueryable();

            if (filter.FromDate.HasValue)
                query = query.Where(x => x.EventTime >= filter.FromDate.Value);

            if (filter.ToDate.HasValue)
                query = query.Where(x => x.EventTime <= filter.ToDate.Value);

            if (!string.IsNullOrWhiteSpace(filter.EventType))
                query = query.Where(x => x.EventType == filter.EventType);

            if (!string.IsNullOrWhiteSpace(filter.ObjectName))
                query = query.Where(x => x.ObjectName.Contains(filter.ObjectName));

            if (!string.IsNullOrWhiteSpace(filter.UserName))
                query = query.Where(x => x.UserName.Contains(filter.UserName));

            var result = await query
                .OrderByDescending(x => x.EventTime)
                .Take(500) // حماية الأداء
                .ToListAsync();

            return Ok(result);
        }

        // GET: api/AuditIndexes/event-types
        [HttpGet("event-types")]
        public async Task<IActionResult> GetEventTypes()
        {
            var types = await _context.Audit_Indexes
                .Select(x => x.EventType)
                .Distinct()
                .ToListAsync();
            return Ok(types);
        }
    }
}