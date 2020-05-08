using System.Threading.Tasks;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IShoppingCart
    {
        Task<int> GetMaxOrderIdAsync();

        void UpdateAmountProduct(int amount, int id);
    }
}
