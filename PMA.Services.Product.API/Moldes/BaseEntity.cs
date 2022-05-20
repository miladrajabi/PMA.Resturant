using System.ComponentModel.DataAnnotations;

namespace PMA.Services.Product.API.Moldes
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
