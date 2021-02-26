using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using WebApi.Areas.Authorization.Models;

namespace WebApi.Profiles
{
    public class UserBaseProfile : Profile
    {
        public UserBaseProfile()
        {
            CreateMap<UserDefault, CustomerDTO>();
            CreateMap<CustomerDTO, UserDefault>();
        }
    }
}
