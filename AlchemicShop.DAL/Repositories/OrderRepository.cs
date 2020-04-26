using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlchemicShop.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private AlchemicShopContext dbContext;

        public OrderRepository(AlchemicShopContext context)
        {
            dbContext = context;
        }

        public void Create(Order item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order item)
        {
            throw new NotImplementedException();
        }

        public Order Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return dbContext.Orders.Where(predicate).ToList();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
