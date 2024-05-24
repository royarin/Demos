using HealthMarket.Data;

namespace HealthMarket.Services
{
    public interface IOrderService
    {
        Order GetNewOrder();
        Task<Order> CreateOrder(Order order);
    }
}
