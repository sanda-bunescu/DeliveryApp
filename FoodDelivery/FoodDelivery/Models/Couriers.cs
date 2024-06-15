using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Models
{
    public class Couriers
    {
        public int CouriersId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public ICollection<Orders>? Orders { get; set; }
        public bool IsDeleted { get; set; }
    }
}
