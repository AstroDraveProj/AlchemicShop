using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System.Data.Entity;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Repositories
{
    public class AccountRepository : IUserAccount<User>
    {
        private readonly AlchemicShopContext _dbContext;

        public AccountRepository(AlchemicShopContext context)
        {
            _dbContext = context;
        }

        public async Task<User> GetUserAsync(string s)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == s);
        }

        public async Task<User> GetUserAsync(User item)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == item.Login && x.Password == item.Password);
        }
    }
}
