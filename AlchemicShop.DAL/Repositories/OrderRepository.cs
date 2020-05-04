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
    public class OrderRepository : IRepository<Order>
    {
        private AlchemicShopContext _dbContext;

        public OrderRepository(AlchemicShopContext context)
        {
            _dbContext = context;
        }

        public void Create(Order item)
        {
            if (item != null)
            {
                _dbContext.Orders.Add(item);
            }
            else throw new ArgumentNullException();
        }

        public void Delete(Order item)
        {
            var deleteItem = _dbContext.Orders.Find(item.Id);
            if (deleteItem != null)
            {
                _dbContext.Orders.Remove(deleteItem);
            }
            else throw new ArgumentNullException();
        }

        public async Task<Order> GetIdAsync(int? id)
        {
            if (id != null)
            {
                return await _dbContext.Orders.FindAsync(id);
            }
            else throw new ArgumentNullException();
        }

        public async Task<Order> FindItemAsync(Func<Order, bool> item)
        {
            return await Task.Run(() => _dbContext.Orders.Where(item).FirstOrDefault());
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public void Update(Order item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
