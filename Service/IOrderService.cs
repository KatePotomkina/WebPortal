using BackPart.Data.DTO;
using BackPart.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackPart.Service;

public interface IOrderService
{
 Task<List<OrderDto>> GetAllOrders();
 Task<Order> AddNewOrder(Order newOrder);
}