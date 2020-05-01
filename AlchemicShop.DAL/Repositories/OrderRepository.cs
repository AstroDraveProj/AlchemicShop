using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            _dbContext.Orders.Add(item);
        }

        public void Delete(Order item)
        {
            if (item != null)
            {
                _dbContext.Orders.Remove(item);
            }
        }

        public Order Get(int? id)
        {
            if (id != null)
            {
                return _dbContext.Orders.Find(id);
            }
            throw new ValidationException();
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return _dbContext.Orders.Where(predicate).ToList();
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public void Update(Order item)
        {
            if (item != null)
            {
                var updateItem = _dbContext.Orders.Find(item.Id);

                if (updateItem != null)
                {
                    updateItem.SheduledDate = item.SheduledDate;
                    updateItem.ClosedDate = item.ClosedDate;
                    updateItem.Status = item.Status;
                }
            }
        }
    }
}
