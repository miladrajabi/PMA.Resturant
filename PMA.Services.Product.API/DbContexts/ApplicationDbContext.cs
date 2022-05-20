using Microsoft.EntityFrameworkCore;

namespace PMA.Services.Product.API.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product.API.Moldes.Product> Products {get;set;}
    }
}
