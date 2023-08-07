using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackPart.Data.DTO;
using BackPart.Data.DTO.Response;
using BackPart.Models;
using BackPart.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackPart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
       
        public OrdersController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddNewOrder([FromBody] NewOrderDto newOrderDto)
        {
            
            var order = new Order
            {
                //OrderId = newOrderDto.OrderId,
                CustomerId = newOrderDto.CustomerId,
                CreatedAt = newOrderDto.CreatedAt,
                OrderItems = newOrderDto.OrderItems.ToList().Select(s => new OrderItem
                {
                    ProductId = s.ProductId,
                    Quantity = s.Quantity
                    
                }).ToList(),
                TotalCost = newOrderDto.TotalCost,
                Comment = newOrderDto.Comment,
                CurrentStatus = newOrderDto.CurrentStatus
            };
            await _orderService.AddNewOrder(order);
            var orderResponse = _mapper.Map<OrderRersponse>(order);
            return Ok(orderResponse);
        }
    }
}


