using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Car, CarDTO>();
            CreateMap<CarDTO, Car>();
        }
    }
}
