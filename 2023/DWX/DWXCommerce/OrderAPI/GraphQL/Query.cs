using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;

namespace OrderAPI.GraphQL
{
    public class Query
    {
        public async Task<IEnumerable<Models.Order>> GetOrders(OrderContext context){
            return await context.Orders.Include(x => x.LineItems).ToListAsync();
        }

        public async Task<Models.Order> GetOrder(int orderNumber, OrderContext context){
            return await context.Orders.Include(x=>x.LineItems).FirstOrDefaultAsync(x=>x.OrderNumber == orderNumber);
        }
    }
}