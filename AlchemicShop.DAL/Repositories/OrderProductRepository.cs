using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlchemicShop.DAL.Repositories
{
    public class OrderProductRepository : IRepository<OrderProduct>
    {
        private AlchemicShopContext dbContext;

        public OrderProductRepository(AlchemicShopContext context)
        {
            dbContext = context;
        }

        public void Create(OrderProduct item)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderProduct item)
        {
            throw new NotImplementedException();
        }

        public OrderProduct Get(int? id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<OrderProduct> Find(Func<OrderProduct, bool> predicate)
        {
            return dbContext.OrderProducts.Where(predicate).ToList();
        }


        public IEnumerable<OrderProduct> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderProduct item)
        {
            throw new NotImplementedException();
        }
    }
}
