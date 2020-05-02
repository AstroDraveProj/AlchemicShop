using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private AlchemicShopContext _dbContext;

        public UserRepository(AlchemicShopContext context)
        {
            _dbContext = context;
        }

        public async Task Create(User item)
        {
            if (item != null)
            {
                await Task.Run(() => _dbContext.Users.Add(item));
            }
            else throw new ArgumentNullException();
        }

        public async Task Delete(User item)
        {
            var deleteItem = await Get(item.Id);
            if (deleteItem != null)
            {
                await Task.Run(() => _dbContext.Users.Remove(deleteItem));
            }
            else throw new ArgumentNullException();
        }

        public async Task<User> Get(int? id)
        {
            if (id != null)
            {
                return await Task.Run(() => _dbContext.Users.Find(id));
            }
            else throw new ArgumentNullException();
        }

        public async Task<User> Find(Func<User, bool> predicate)
        {
            return await Task.Run(() => _dbContext.Users.Where(predicate).FirstOrDefault());
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _dbContext.Users.ToList());
        }

        public async Task Update(User item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
