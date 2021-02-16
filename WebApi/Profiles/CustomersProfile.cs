using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
