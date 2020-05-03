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
        public async Task Create(Category item)
        {
            if (item != null)
            {
                await Task.Run(() => _dbContext.Categories.Add(item));
            }
            else throw new ArgumentNullException();
        }

        public async Task Delete(Category item)
        {
            var deleteItem = await Get(item.Id);
            if (deleteItem != null)
            {
                await Task.Run(() => _dbContext.Categories.Remove(deleteItem));
            }
            else throw new ArgumentNullException();
        }

        public async Task<Category> Get(int? id)
        {
            if (id != null)
            {
                return await Task.Run(() => _dbContext.Categories.Find(id));
            }
            else throw new ArgumentNullException();
        }
        public async Task<Category> Find(Func<Category, bool> predicate)
        {
            return await Task.Run(() => _dbContext.Categories.Where(predicate).FirstOrDefault());
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await Task.Run(() => _dbContext.Categories.ToList());
        }

        public async Task Update(Category item)
        {
           _dbContext.Entry(item).State = EntityState.Modified;
        }

    }
}
