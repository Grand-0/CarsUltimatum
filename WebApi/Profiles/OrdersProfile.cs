using AutoMapper;
using BusinessLogicLayer.ModelsDTO;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
