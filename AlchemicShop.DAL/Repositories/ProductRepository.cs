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
    public class ProductRepository : IRepository<Product>
    {
        private AlchemicShopContext _dbContext;

        public ProductRepository(AlchemicShopContext context)
        {
            _dbContext = context;
        }

        public async Task Create(Product item)
        {
            if (item != null)
            {
                await Task.Run(() => _dbContext.Products.Add(item));
            }
            else throw new ArgumentNullException();
        }

        public async Task Delete(Product item)
        {
            var deleteItem = await Get(item.Id);
            if (deleteItem != null)
            {
                await Task.Run(() => _dbContext.Products.Remove(deleteItem));
            }
            else throw new ArgumentNullException();
        }

        public async Task<Product> Get(int? id)
        {
            if (id != null)
            {
                return await Task.Run(() => _dbContext.Products.Find(id));
            }
            else throw new ArgumentNullException();

        }

        public async Task<Product> Find(Func<Product, bool> predicate)
        {
            return await Task.Run(() => _dbContext.Products.Where(predicate).FirstOrDefault());
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await Task.Run(() => _dbContext.Products
                .Include(x => x.Category));
        }

        public async Task Update(Product item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
