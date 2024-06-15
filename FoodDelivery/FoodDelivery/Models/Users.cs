using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Models
{
    public class Users
    {
        public int UsersId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? DeliveryAddress { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Orders>? Orders { get; set; }
    }
}
