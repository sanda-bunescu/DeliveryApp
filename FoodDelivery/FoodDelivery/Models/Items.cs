using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{
    public class Items
    {
        public int ItemsId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [ForeignKey("MenusID")]
        public int MenusID { get; set; }
        public Menus? Menu { get; set; }
        public ICollection<Orders> Orders { get; set; } = new List<Orders>();

    }
}
