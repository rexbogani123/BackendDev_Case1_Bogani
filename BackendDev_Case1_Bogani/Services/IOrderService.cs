
using BackendDev_Case1_Bogani.DTOs;
namespace BackendDev_Case1_Bogani.Services
{
    public interface IOrderService
{
    Task<List<OrderDto>> GetAllOrdersAsync();
    Task<OrderDto> GetOrderByIdAsync(int id);
    Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
    Task UpdateOrderAsync(int id, OrderDto orderDto);
    Task DeleteOrderAsync(int id);
}
}