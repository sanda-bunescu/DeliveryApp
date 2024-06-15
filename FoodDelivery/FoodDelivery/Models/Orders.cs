using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{
    public class Orders
    {
        public int OrdersId { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public ICollection<Items> Items { get; set; } = new List<Items>();
        public Restaurants? Restaurant { get; set; }
        public Payments? Payment { get; set; }
        public Couriers? Courier { get; set; }
        public Users? User { get; set; }
    }
}
