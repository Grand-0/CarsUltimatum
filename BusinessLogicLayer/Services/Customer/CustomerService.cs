using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using CustomerEntity = DataAccessLayer.Entities.Customer;
using DataAccessLayer.Repository.UnitOfWork;
using BusinessLogicLayer.Exceptions;

namespace BusinessLogicLayer.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork Database;
        private IMapper _mapper;

        public CustomerService(IUnitOfWork unit, IMapper mapper)
        {
            Database = unit;
            _mapper = mapper;
        }
        public void AddCustomer(CustomerDTO customer)
        {
            Database.CustomerRepository.AddCustomer(_mapper.Map<CustomerEntity>(customer));

            Database.Save();
        }

        public void DeleteCustomer(int id)
        {
            CustomerEntity customer = Database.CustomerRepository.GetCustomerById(id);
            
            if(customer == null)
            {
                throw new ValidationException("Не найден пользователь с данным ключом!",""); 
            }

            Database.CustomerRepository.DeleteCustomer(customer);

            Database.Save();
        }

        public CustomerDTO GetCustomer(string login, string password)
        {
            return _mapper.Map<CustomerDTO>(Database.CustomerRepository.GetCustomer(login, password));
        }

        public CustomerDTO GetCustomerById(int id)
        {
            return _mapper.Map<CustomerDTO>(Database.CustomerRepository.GetCustomerById(id));
        }

        public void UpdateCustomer(CustomerDTO customer)
        {
            Database.CustomerRepository.UpdateCustomer(_mapper.Map<CustomerEntity>(customer));

            Database.Save();
        }
    }
}
