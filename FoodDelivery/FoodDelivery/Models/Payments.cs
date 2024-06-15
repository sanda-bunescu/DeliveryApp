using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Models
{
    public class Payments
    {
        public int PaymentsId { get; set; }
        [Required]
        public string? PaymentMethod { get; set; }
        public int PaymentAmount { get; set; }

        [ForeignKey("OrdersId")]
        public int OrdersId { get; set; }
        [Required]
        public Orders? Orders { get; set; }
    }
}
