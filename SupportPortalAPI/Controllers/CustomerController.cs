using Microsoft.AspNetCore.Mvc;
using SupportPortalAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SupportPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetCustomerByPhone(string phoneNumber)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
            if (customer == null) return NotFound();
            return Ok(customer);
        }
    }
}