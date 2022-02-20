using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Products = new HashSet<Product>();
        }
                
        public string FirstName { get; set; }

        public string? LastName { get; set; }
                
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}