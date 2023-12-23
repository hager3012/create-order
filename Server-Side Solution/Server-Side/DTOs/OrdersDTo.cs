using System.ComponentModel.DataAnnotations;

namespace Server_Side.DTOs
{
    public class OrdersDTo
    {
        public int? OrderId { get; set; }
        [Required]
        public string customerName { get; set; }
        [Required]
        public DateTime orderDate { get; set; } 

        public ICollection<OrderDetailsDTO> OrderDetails { get; set; } = new HashSet<OrderDetailsDTO>();
        public decimal Total => OrderDetails.Sum(od => od.price * od.quantity);
    }
}
