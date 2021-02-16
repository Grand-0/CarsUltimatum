using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository.CustomerRepository
{
    public class CustomersRepository : ICustomerRepository
    {
        private CarsUltimatedb _db;
        public CustomersRepository(CarsUltimatedb ultimatedb)
        {
            _db = ultimatedb;
        }

        public void AddCustomer(Customer customer)
        {
            customer.Role = "Customer";
            _db.Customers.Add(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _db.Customers.Remove(customer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _db.Customers.ToList();
        }

        public Customer GetCustomer(string login, string password)
        {
            return _db.Customers.Where(c => c.Login == login && c.Password == password).FirstOrDefault();
        }

        public Customer GetCustomerById(int id)
        {
            return _db.Customers.Find(id);
        }

        public IQueryable<Customer> GetCustomerByPredicate(Func<Customer, bool> predicate)
        {
            return _db.Customers.Where(predicate).AsQueryable();
        }

        public void UpdateCustomer(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Modified;
        }
    }
}
