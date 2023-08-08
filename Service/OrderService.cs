using BackPart.Data.DTO;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BackPart.Data.DTO.Response;
using BackPart.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackPart.Service;

public class OrderService : IOrderService
{
    private readonly OrdersContext _context;
    private readonly IMapper _mapper;

    public OrderService(OrdersContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> GetAllOrders()
    {
        var orders = await _context.Orders
            .Include(od => od.Customer)
            .Include(oi => oi.OrderItems)
            .ThenInclude(otc => otc.Product) // Include the Customer entity inside OrderToCustomer
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider) // Use AutoMapper here
            .ToListAsync();

        return orders;
    }


    public async Task<Order> AddNewOrder(Order newOrder)
    {
        /*_context.Orders.Add(newOrder); // Use Add method if not using async
        await _context.SaveChangesAsync(); // Make sure to await the SaveChangesAsync

        return newOrder;*/
        var order = new Order
        {
            //OrderId = newOrderDto.OrderId,
            CustomerId = newOrder.CustomerId,
            CreatedAt = newOrder.CreatedAt,
            OrderItems = newOrder.OrderItems.ToList().Select(s => new OrderItem
            {
                ProductId = '1',
                Quantity = '2'


            }).ToList(),
            TotalCost = newOrder.OrderItems.Sum(orderItem =>
                _context.Products.First(p => p.ProductId == orderItem.ProductId).Price * orderItem.Quantity),
            Comment = newOrder.Comment,
            CurrentStatus = newOrder.CurrentStatus
        };

        await _context.AddAsync(order);
        var orderResponse = _mapper.Map<OrderRersponse>(order);
        return order;
    }
    

    public decimal CalculateTotalCostAndMapToDto()
    {
        var order = new Order();

        var totalCost = order.OrderItems.Sum(orderItem =>
            orderItem.Product.Price * orderItem.Quantity);

        return totalCost;
    }

}


 

    


