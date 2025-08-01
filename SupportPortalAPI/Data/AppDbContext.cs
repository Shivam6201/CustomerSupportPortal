using Microsoft.EntityFrameworkCore;
using SupportPortalAPI.Models;

namespace SupportPortalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CallLog> CallLogs { get; set; }
    }
}
