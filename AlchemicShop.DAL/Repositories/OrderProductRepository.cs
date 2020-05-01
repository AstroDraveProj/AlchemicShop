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

        public async Task Create(OrderProduct item)
        {
            if (item != null)
            {
                await Task.Run(() => _dbContext.OrderProducts.Add(item));
                await _dbContext.SaveChangesAsync();
            }
            else throw new ArgumentNullException();
        }

        public async Task Delete(OrderProduct item)
        {
            var deleteItem = await Get(item.Id);
            if (deleteItem != null)
            {
                await Task.Run(() => _dbContext.OrderProducts.Remove(deleteItem));

                await _dbContext.SaveChangesAsync();
            }
            else throw new ArgumentNullException();
        }

        public async Task<OrderProduct> Get(int? id)
        {
            if (id != null)
            {
                return await Task.Run(() => _dbContext.OrderProducts.Find(id));
            }
            else throw new ArgumentNullException();
        }
        public async Task<IEnumerable<OrderProduct>> Find(Func<OrderProduct, bool> predicate)
        {
            return await Task.Run(() => _dbContext.OrderProducts.Where(predicate).ToList());
        }

        public async Task<IEnumerable<OrderProduct>> GetAll()
        {
            return await Task.Run(() => _dbContext.OrderProducts
               .Include(x => x.OrderId));
        }

        public async Task Update(OrderProduct item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
