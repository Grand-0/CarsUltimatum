using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
        }
    }
}
