using System.Threading.Tasks;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IUserAccount<T> where T : class
    {
        Task<T> GetUserAsync(T item);

        Task<T> GetUserAsync(string item);
    }
}
