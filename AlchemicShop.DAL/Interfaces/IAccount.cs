using AlchemicShop.DAL.Entities;

namespace AlchemicShop.DAL.Interfaces
{
    public interface IAccount<T> where T : class
    {
        User GetUserAccount(string login, string password);
    }
}
