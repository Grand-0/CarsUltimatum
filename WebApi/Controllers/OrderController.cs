using AutoMapper;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.ModelsDTO;
using BusinessLogicLayer.Services.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private OrderService _service;
        private IMapper _mapper;
        public OrderController(OrderService orderService, IMapper mapper)
        {
            _service = orderService;
            _mapper = mapper;
        }

        [HttpGet("GetMyOrders")]
        public ActionResult GetMyOrders(int customerID)
        {
            IEnumerable<Order> orders;

            try
            {
                orders = _mapper.Map<IEnumerable<Order>>(_service.GetOrders(customerID));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(orders);
        }
        
        [HttpGet("GetOrder/{orderId}")]
        public ActionResult GetCarsInOrder(int orderId)
        {
            Order order;

            try
            {
                order = _mapper.Map<Order>(_service.GetOrderByID(orderId));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(order);
        }

        [HttpPost("MakeOrder")]
        public ActionResult MakeOrder(Order order)
        {
            try
            {
                _service.MakeOrder(_mapper.Map<OrderDTO>(order));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Заказ успешно оформлен");
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteOrder(int id)
        {
            try
            {
                _service.DeleteOrder(id);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Заказ успешно удалён");
        }
    }
}
