using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{
    public class Restaurants
    {
        public int RestaurantsId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public Menus? Menu { get; set; }
        public ICollection<Orders>? Orders { get; set; }

    }
}
