using System.ComponentModel.DataAnnotations;

namespace PMA.Services.Product.API.Moldes
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

    }
}
