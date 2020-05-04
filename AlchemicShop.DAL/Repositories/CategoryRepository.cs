using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private AlchemicShopContext _dbContext;

        public CategoryRepository(AlchemicShopContext context)
        {
            _dbContext = context;
        }
        public void Create(Category item)
        {
            if (item != null)
            {
                _dbContext.Categories.Add(item);
            }
            else throw new ArgumentNullException();
        }

        public void Delete(Category item)
        {
            var deleteItem = _dbContext.Categories.Find(item);
            if (deleteItem != null)
            {
                _dbContext.Categories.Remove(deleteItem);
            }
            else throw new ArgumentNullException();
        }

        public async Task<Category> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbContext.Categories.FindAsync(id);
            }
            else throw new ArgumentNullException();
        }

        public async Task<Category> FindItemAsync(Func<Category, bool> item)
        {
            return await Task.Run(() => _dbContext.Categories.Where(item).FirstOrDefault());
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public void Update(Category item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
