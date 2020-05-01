using AlchemicShop.DAL.Entities;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IAccount<T> where T : class
    {
        Task<User> GetUserAccount(string login, string password);
    }
}
