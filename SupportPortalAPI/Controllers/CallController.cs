using Microsoft.AspNetCore.Mvc;
using SupportPortalAPI.Data;
using SupportPortalAPI.Models;

namespace SupportPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CallController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("log")]
        public IActionResult LogCall([FromBody] CallLog log)
        {
            log.CallTime = DateTime.Now;
            _context.CallLogs.Add(log);
            _context.SaveChanges();
            return Ok();
        }
    }
}