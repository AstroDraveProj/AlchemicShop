using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;
using System.Threading.Tasks;

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
            return await _dbOperation.ShoppingCart.GetMaxOrderIdAsync();
        }

        public async Task UpdateProductAmount(int amount, int id)
        {
            _dbOperation.ShoppingCart.UpdateAmountProduct(amount, id);
            await _dbOperation.Save();
        }
    }
}
