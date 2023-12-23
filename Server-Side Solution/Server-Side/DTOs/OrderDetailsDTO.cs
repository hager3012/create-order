using System.ComponentModel.DataAnnotations;

namespace Server_Side.DTOs
{
    public class OrderDetailsDTO
    {
        [Required]
        public string productName { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int quantity { get; set; }
        [Required]
        [Range(0.1, int.MaxValue)]
        public decimal price { get; set; }
    }
}
