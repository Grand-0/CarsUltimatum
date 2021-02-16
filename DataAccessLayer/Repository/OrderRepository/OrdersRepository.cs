using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository.OrderRepository
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly CarsUltimatedb _db;
        public OrdersRepository(CarsUltimatedb db)
        {
            _db = db;
        }

        public void Add(Order order)
        {
            _db.Orders.Add(order);
        }

        public void Delete(Order order)
        {
            _db.Orders.Remove(order);
        }

        public IEnumerable<Order> GetAllOrders(int customerId)
        {
            return _db.Orders.Where(o => o.CustomerID == customerId).ToList();
        }

        public Order GetOrderByID(int orderId)
        {
            return _db.Orders.Find(orderId);
        }

        public IEnumerable<Order> GetOrdersByPredicate(Func<Order, bool> predicate)
        {
            return _db.Orders.Where(predicate).ToList();
        }

        public void Update(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }
    }
}
