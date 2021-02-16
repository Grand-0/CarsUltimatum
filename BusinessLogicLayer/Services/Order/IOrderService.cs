using BusinessLogicLayer.ModelsDTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO order);
        void DeleteOrder(int orderId);
        void UpdateOrder(OrderDTO order);
        IEnumerable<OrderDTO> GetOrders(int customerId);
        OrderDTO GetOrderByID(int orderId);
    }
}
