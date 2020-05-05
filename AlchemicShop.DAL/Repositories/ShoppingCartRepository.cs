using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Repositories
{
    class ShoppingCartRepository : IShoppingCart<Order>
    {
        private AlchemicShopContext _dbContext;

        public ShoppingCartRepository(AlchemicShopContext context)
        {
            _dbContext = context;
        }

        public async Task<int> GetMaxOrderIdAsync()
        {
            return await _dbContext.Orders.MaxAsync(order => order.Id);
        }
    }
}
