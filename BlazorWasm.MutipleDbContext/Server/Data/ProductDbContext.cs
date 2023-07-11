using BlazorWasm.MutipleDbContext.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasm.MutipleDbContext.Server.Data
{

    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }

}
