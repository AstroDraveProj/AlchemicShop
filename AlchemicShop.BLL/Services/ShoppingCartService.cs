using AlchemicShop.BLL.Interfaces;
using AlchemicShop.DAL.Interfaces;

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

        public int GetMax()
        {
            return _dbOperation.MaxOrder.GetMax();
        }

        //fail
        public int GetOrderId(string s)
        {
            return _dbOperation.MaxOrder.GetMaxId(s);
        }
    }
}
