using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System.Linq;

namespace AlchemicShop.DAL.Repositories
{
    public class AccountRepository : IAccount<User>
    {
        private AlchemicShopContext dbContext;

        public AccountRepository(AlchemicShopContext context)
        {
            dbContext = context;
        }

        public User GetUserAccount(string login, string password)
        {
            return dbContext.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
        }
    }
}
