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
    public class OrderProductRepository : IRepository<OrderProduct>
    {
        private AlchemicShopContext _dbContext;

        public OrderProductRepository(AlchemicShopContext context)
        {
            _dbContext = context;
        }

        public void Create(OrderProduct item)
        {
            if (item != null)
            {
                _dbContext.OrderProducts.Add(item);
            }
            else throw new ArgumentNullException();
        }

        public void Delete(OrderProduct item)
        {
            var deleteItem = _dbContext.OrderProducts.Find(item);
            if (deleteItem != null)
            {
                _dbContext.OrderProducts.Remove(deleteItem);

            }
            else throw new ArgumentNullException();
        }

        public async Task<OrderProduct> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbContext.OrderProducts.FindAsync(id);
            }
            else throw new ArgumentNullException();
        }

        public async Task<OrderProduct> FindItemAsync(Func<OrderProduct, bool> item)
        {
            return await Task.Run(() => _dbContext.OrderProducts.Where(item).FirstOrDefault());
        }

        public async Task<IEnumerable<OrderProduct>> GetAllAsync()
        {
            return await _dbContext.OrderProducts
               .Include(x => x.OrderId).ToListAsync();
        }

        public void Update(OrderProduct item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
