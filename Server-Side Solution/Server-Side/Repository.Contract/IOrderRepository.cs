
using Server_Side.DTOs;

namespace Server_Side.Repository.Contract
{
    public interface IOrderRepository
    {
        string? AddOrder(OrdersDTo orders);
    }
}
