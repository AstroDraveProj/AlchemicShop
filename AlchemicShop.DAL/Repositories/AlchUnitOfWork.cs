﻿using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;

namespace AlchemicShop.DAL.Repositories
{
    public class AlchUnitOfWork : IUnitOfWork
    {
        private AlchemicShopContext dbContext;
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;
        private OrderRepository orderRepository;
        private OrderProductRepository orderProductRepository;
        private UserRepository userRepository;

        public AlchUnitOfWork(string connection)
        {
            dbContext = new AlchemicShopContext(connection);
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(dbContext);
                return productRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(dbContext);
                return categoryRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(dbContext);
                return userRepository;
            }
        }

        public IRepository<OrderProduct> OrderProducts
        {
            get
            {
                if (orderProductRepository == null)
                    orderProductRepository = new OrderProductRepository(dbContext);
                return orderProductRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(dbContext);
                return orderRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}