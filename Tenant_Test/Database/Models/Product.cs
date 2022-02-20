using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}