using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository.CustomerRepository
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

        Customer GetCustomerById(int id);
        IQueryable<Customer> GetCustomerByPredicate(Func<Customer, Boolean> predicate);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(string login, string password);
    }
}
