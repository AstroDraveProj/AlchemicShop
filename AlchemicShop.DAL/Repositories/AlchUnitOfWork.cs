using AlchemicShop.DAL.AlchemicDbContext;
using AlchemicShop.DAL.Entities;
using AlchemicShop.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace AlchemicShop.DAL.Repositories
{
    public class AlchUnitOfWork : IUnitOfWork
    {
        private readonly AlchemicShopContext _dbContext;

        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;
        private OrderRepository orderRepository;
        private OrderProductRepository orderProductRepository;
        private UserRepository userRepository;
        private ShoppingCartRepository scRepository;

        public AlchUnitOfWork(string connection)
        {
            _dbContext = new AlchemicShopContext(connection);
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(_dbContext);
                return productRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(_dbContext);
                return categoryRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_dbContext);
                return userRepository;
            }
        }

        public IRepository<OrderProduct> OrderProducts
        {
            get
            {
                if (orderProductRepository == null)
                    orderProductRepository = new OrderProductRepository(_dbContext);
                return orderProductRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(_dbContext);
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

        public IShoppingCart<Order> MaxOrder
        {
            get
            {
                if (scRepository == null)
                    scRepository = new ShoppingCartRepository(_dbContext);
                return scRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
