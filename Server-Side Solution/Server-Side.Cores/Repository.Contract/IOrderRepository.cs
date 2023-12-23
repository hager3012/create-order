
using Server_Side.Cores.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Side.Cores.Repository.Contract
{
    public interface IOrderRepository
    {
        void AddOrder(Orders orders);
        Orders GetOrder(int Id);
        Orders GetAllOrders();
    }
}
