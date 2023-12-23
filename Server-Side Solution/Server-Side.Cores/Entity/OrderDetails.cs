using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Side.Cores.Entity
{
    public class OrderDetails
    {

        public int orderId { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
}
