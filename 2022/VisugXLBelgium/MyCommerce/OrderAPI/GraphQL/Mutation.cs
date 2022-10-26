using System.Reflection;
using System.Threading.Tasks;
using HotChocolate;
using OrderAPI.Data;
using Mapster;

namespace OrderAPI.GraphQL
{
    public class Mutation
    {
        public async Task<Models.Order> CreateOrder(CreateOrderInput createOrderInput, OrderContext context){
            var newOrder=createOrderInput.Adapt<Models.Order>();

            await context.Orders.AddAsync(newOrder);
            await context.SaveChangesAsync();

            return newOrder;
        }
    }
}