using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Side.Cores.Entity
{
    public class Orders
    {
        public string customerName { get; set; }
        public DateTimeOffset orderDate { get; set; } = DateTimeOffset.UtcNow;
        public decimal Total { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; } = new HashSet<OrderDetails>();
    }
}
