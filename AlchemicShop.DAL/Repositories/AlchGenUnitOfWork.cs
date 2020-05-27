using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Interfaces;
using AlchemicShop.DAL.Entities;
using System.Threading.Tasks;
using System;

namespace AlchemicShop.DAL.Repositories
{
    public class AlchGenUnitOfWork : IUnitOfWork
    {
        private readonly AlchemicShopContext _dbContext;

        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<OrderProduct> orderProductRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<User> userRepository;

        public AlchGenUnitOfWork(string connection)
        {
            _dbContext = new AlchemicShopContext(connection);
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new GenericRepository<Product>(_dbContext);
                return productRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new GenericRepository<Category>(_dbContext);
                return categoryRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new GenericRepository<User>(_dbContext);
                return userRepository;
            }
        }

        public IRepository<OrderProduct> OrderProducts
        {
            get
            {
                if (orderProductRepository == null)
                    orderProductRepository = new GenericRepository<OrderProduct>(_dbContext);
                return orderProductRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new GenericRepository<Order>(_dbContext);
                return orderRepository;
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
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
