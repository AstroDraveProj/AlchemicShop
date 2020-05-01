using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private AlchemicShopContext _dbContext;

        public OrderRepository(AlchemicShopContext context)
        {
            _dbContext = context;
        }

        public async Task  Create(Order item)
        {
            if (item != null)
            {
                await Task.Run(() => _dbContext.Orders.Add(item));
                await _dbContext.SaveChangesAsync();
            }
            else throw new ArgumentNullException();
        }

        public async Task Delete(Order item)
        {
            var deleteItem = await Get(item.Id);
            if (deleteItem != null)
            {
                await Task.Run(() => _dbContext.Orders.Remove(deleteItem));
                await _dbContext.SaveChangesAsync();
            }
            else throw new ArgumentNullException();
        }

        public async Task<Order> Get(int? id)
        {
            if (id != null)
            {
                return await Task.Run(() => _dbContext.Orders.Find(id));
            }
            else throw new ArgumentNullException();
        }

        public async Task<IEnumerable<Order>> Find(Func<Order, bool> predicate)
        {
            return await Task.Run(() => _dbContext.Orders.Where(predicate).ToList());
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await Task.Run(() => _dbContext.Orders.ToList());
        }

        public async Task Update(Order item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
