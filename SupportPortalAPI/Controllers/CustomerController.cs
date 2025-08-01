using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportPortalAPI.Data;

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

        // GET: api/customer/{phoneNumber}
        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetCustomerByPhone([FromRoute] string phoneNumber)
        {
            var customer = await _context.Customers
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);

            if (customer == null)
                return NotFound(new { message = "Customer not found." });

            return Ok(customer);
        }
    }
}
