using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlchemicShop.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private AlchemicShopContext dbContext;

        public CategoryRepository(AlchemicShopContext context)
        {
            dbContext = context;
        }
        public void Create(Category item)
        {
            dbContext.Categories.Add(item);
        }

        public void Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Category Get(int? id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return dbContext.Categories.Where(predicate).ToList();
        }

        public IEnumerable<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }

    }
}
