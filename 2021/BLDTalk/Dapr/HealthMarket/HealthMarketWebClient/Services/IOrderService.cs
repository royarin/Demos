using HealthMarketWebClient.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthMarketWebClient.Services
{
    public interface IOrderService
    {
        Order GetNewOrder();
        Task SaveOrder(Order order);
    }
}
