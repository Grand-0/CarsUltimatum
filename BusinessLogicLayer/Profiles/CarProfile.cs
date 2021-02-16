using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarDTO, Car>();
            CreateMap<Car, CarDTO>();
        }
    }
}
