using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Repositories
{
    public class AccountRepository : IAccount<User>
    {
        private AlchemicShopContext dbContext;

        public AccountRepository(AlchemicShopContext context)
        {
            dbContext = context;
        }

        public async Task<User> GetUserAccount(string login, string password)
        {
            return await Task.Run(() => dbContext.Users.FirstOrDefault(x => x.Login == login && x.Password == password));
        }
    }
}
