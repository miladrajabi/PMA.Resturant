using Microsoft.EntityFrameworkCore;

namespace PMA.Services.Product.API.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product.API.Moldes.Product> Products {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product.API.Moldes.Product>().HasData(new Moldes.Product
            {
                Id=10,
                Name="Samosa",
                Price=15,
                Description="This is my product",
                ImageUrl="",
                CategoryName="Appetizer"
            });

            modelBuilder.Entity<Product.API.Moldes.Product>().HasData(new Moldes.Product
            {
                Id = 11,
                Name = "Iphone",
                Price = 150,
                Description = "This is my product",
                ImageUrl = "",
                CategoryName = "Mobile"
            });

        }
    }
}
