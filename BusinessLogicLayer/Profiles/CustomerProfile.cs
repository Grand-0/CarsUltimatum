using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
