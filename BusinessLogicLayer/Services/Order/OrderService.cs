using BusinessLogicLayer.ModelsDTO;
using System.Collections.Generic;
using DataAccessLayer.Repository.UnitOfWork;
using AutoMapper;
using BusinessLogicLayer.Exceptions;
using OrderEntity = DataAccessLayer.Entities.Order;
using CarEntity = DataAccessLayer.Entities.Car;

namespace BusinessLogicLayer.Services.Order
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork Database;
        private IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Database = unitOfWork;
            _mapper = mapper;
        }

        public void DeleteOrder(int orderId)
        {
            OrderEntity order = Database.OrdersRepository.GetOrderByID(orderId);
            
            if (order == null)
                throw new ValidationException("Заказа с таким ключом не существует", "");
           
            Database.OrdersRepository.Delete(order);

            Database.Save();
        }

        public void MakeOrder(OrderDTO order)
        {
            Database.OrdersRepository.Add(_mapper.Map<OrderEntity>(order));

            List<CarDTO> cars = order.Cars;

            foreach(CarDTO car in cars)
            {
                Database.CarsRepository.UpdateCount(_mapper.Map<CarEntity>(car));
            }

            Database.Save();
        }

        public IEnumerable<OrderDTO> GetOrders(int customerId)
        {
            return _mapper.Map<IEnumerable<OrderDTO>>(Database.OrdersRepository.GetAllOrders(customerId));
        }

        public OrderDTO GetOrderByID(int orderId)
        {
            OrderDTO order = _mapper.Map<OrderDTO>(Database.OrdersRepository.GetOrderByID(orderId));

            if (order == null)
                throw new ValidationException("Заказа с данным ключом не существует", "");

            return order;
        }

        public void UpdateOrder(OrderDTO order)
        {
            Database.OrdersRepository.Update(_mapper.Map<OrderEntity>(order));

            Database.Save();
        }
    }
}
