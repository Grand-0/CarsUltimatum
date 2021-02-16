using BusinessLogicLayer.ModelsDTO;

namespace BusinessLogicLayer.Services.Customer
{
    public interface ICustomerService
    {
        void AddCustomer(CustomerDTO customer);
        void UpdateCustomer(CustomerDTO customer);
        void DeleteCustomer(int id);

        CustomerDTO GetCustomerById(int id);
        CustomerDTO GetCustomer(string login, string password);
    }
}
