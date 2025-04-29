using BackendDev_Case1_Bogani.DTOs;
using BackendDev_Case1_Bogani.Data;
using BackendDev_Case1_Bogani.Model;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace BackendDev_Case1_Bogani.Services
{
    public class OrderService : IOrderService
{
    private readonly ECommerceDbContext _context;

    public OrderService(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrderDto>> GetAllOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .Select(o => new OrderDto
            {
                Id = o.Id,
                CustomerName = o.CustomerName,
                OrderDate = o.OrderDate,
                OrderItems = o.OrderItems.Select(i => new OrderItemDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            }).ToListAsync();
    }

    public async Task<OrderDto> GetOrderByIdAsync(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            return null;

        return new OrderDto
        {
            Id = order.Id,
            CustomerName = order.CustomerName,
            OrderDate = order.OrderDate,
            OrderItems = order.OrderItems.Select(i => new OrderItemDto
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };
    }

    public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
    {
        var order = new Order
        {
            CustomerName = orderDto.CustomerName,
            OrderDate = orderDto.OrderDate,
            OrderItems = orderDto.OrderItems.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        orderDto.Id = order.Id;
        return orderDto;
    }

    public async Task UpdateOrderAsync(int id, OrderDto orderDto)
    {
        var existingOrder = await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (existingOrder == null)
            throw new KeyNotFoundException("Order not found.");

        existingOrder.CustomerName = orderDto.CustomerName;
        existingOrder.OrderDate = orderDto.OrderDate;

        // Remove existing items and replace with new ones
        _context.OrderItems.RemoveRange(existingOrder.OrderItems);
        existingOrder.OrderItems = orderDto.OrderItems.Select(i => new OrderItem
        {
            ProductId = i.ProductId,
            Quantity = i.Quantity,
            UnitPrice = i.UnitPrice
        }).ToList();

        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            throw new KeyNotFoundException("Order not found.");

        _context.OrderItems.RemoveRange(order.OrderItems);
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}
}