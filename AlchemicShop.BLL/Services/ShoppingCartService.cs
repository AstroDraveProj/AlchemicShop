using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace AlchemicShop.BLL.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork _dbOperation;

        public ShoppingCartService(
            IUnitOfWork uow)
        {
            _dbOperation = uow;
        }

        public async Task<int> GetMaxOrderIdAsync()
        {
            var orders = await _dbOperation.Orders.GetAllAsync();

            return orders.Max(x => x.Id);
        }

        public async Task UpdateProductAmount(int amount, int id)
        {
            var product = await _dbOperation.Products.GetIdAsync(id);
            product.Amount -= amount;
            _dbOperation.Products.Update(product);
            await _dbOperation.Save();
        }
    }
}
