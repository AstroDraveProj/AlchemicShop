using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;

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
