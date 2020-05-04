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

        public void Create(Product item)
        {
            if (item != null)
            {
                _dbContext.Products.Add(item);
            }
            else throw new ArgumentNullException();
        }

        public void Delete(Product item)
        {
            var deleteItem = _dbContext.Products.Find(item.Id);
            if (deleteItem != null)
            {
                _dbContext.Products.Remove(deleteItem);
            }
            else throw new ArgumentNullException();
        }

        public async Task<Product> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbContext.Products.FindAsync(id);
            }
            else throw new ArgumentNullException();
        }

        public async Task<Product> FindItemAsync(Func<Product, bool> item)
        {
            return await Task.Run(() => _dbContext.Products.Where(item).FirstOrDefault());
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products
                .Include(x => x.Category).ToListAsync();
        }

        public void Update(Product item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
