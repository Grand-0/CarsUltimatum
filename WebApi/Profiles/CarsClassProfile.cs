using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class CarsClassProfile : Profile
    {
        public CarsClassProfile()
        {
            CreateMap<CarClass, CarClassDTO>();
            CreateMap<CarClassDTO, CarClass>();
        }
    }
}
