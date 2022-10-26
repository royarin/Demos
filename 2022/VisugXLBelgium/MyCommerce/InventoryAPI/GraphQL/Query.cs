using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using InventoryAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.GraphQL
{
    public class Query
    {
        public async Task<Models.Inventory> GetInventory(string sku, InventoryContext context)
        {
            return await context.Inventory.Where(x => x.SKU == sku).FirstOrDefaultAsync();
        }
    }
}