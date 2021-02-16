using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Profiles
{
    public class CarClassProfile : Profile
    {
        public CarClassProfile()
        {
            CreateMap<CarClassDTO, CarClass>();
            CreateMap<CarClass, CarClassDTO>();
        }
    }
}
