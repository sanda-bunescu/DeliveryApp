using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{
    public class Menus
    {
        public int MenusID { get; set; }
        [ForeignKey("RestaurantsId")]
        public int RestaurantsId { get; set; }
        public Restaurants? Restaurant { get; set; }
        public ICollection<Items>? Items { get; set; }
    }
}
