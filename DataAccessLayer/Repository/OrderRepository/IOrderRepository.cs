using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Repository.OrderRepository
{
    public interface IOrderRepository
    {
        Order GetOrderByID(int orderId);
        IEnumerable<Order> GetAllOrders(int customerId);
        IEnumerable<Order> GetOrdersByPredicate(Func<Order, Boolean> predicate);

        void Add(Order order);
        void Delete(Order order);
        void Update(Order order);
    }
}
