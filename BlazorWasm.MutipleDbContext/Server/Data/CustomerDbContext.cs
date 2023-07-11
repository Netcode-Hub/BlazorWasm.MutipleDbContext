using BlazorWasm.MutipleDbContext.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasm.MutipleDbContext.Server.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
