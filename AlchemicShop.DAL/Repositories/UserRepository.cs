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

        public void Create(User item)
        {
            if (item != null)
            {
                _dbContext.Users.Add(item);
            }
            else throw new ArgumentNullException();
        }

        public void Delete(User item)
        {
            var deleteItem = _dbContext.Users.Find(item.Id);
            if (deleteItem != null)
            {
                _dbContext.Users.Remove(deleteItem);
            }
            else throw new ArgumentNullException();
        }

        public async Task<User> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbContext.Users.FindAsync(id);
            }
            else throw new ArgumentNullException();
        }

        public async Task<User> FindItemAsync(Func<User, bool> item)
        {
            return await Task.Run(() => _dbContext.Users
            .Where(item).FirstOrDefault()); ;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public void Update(User item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
