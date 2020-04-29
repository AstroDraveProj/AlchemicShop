﻿using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace AlchemicShop.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private AlchemicShopContext dbContext;

        public ProductRepository(AlchemicShopContext context)
        {
            dbContext = context;
        }

        public void Create(Product item)
        {
            if (item != null)
            {
                dbContext.Products.Add(item);
            }
        }

        public void Delete(Product item)
        {
            var deleteItem = Get(item.Id);
            if (deleteItem != null)
            {
                dbContext.Products.Remove(deleteItem);
            }
            dbContext.SaveChanges();
        }

        public Product Get(int? id)
        {
            return dbContext.Products.Find(id);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return dbContext.Products.Where(predicate).ToList();
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products
                .Include(x => x.Category);
        }

        public void Update(Product item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
