using AlchemicShop.DAL.Entities;
using System.Data.Entity;

namespace AlchemicShop.DAL.AlchemicDbContext
{
    public class AlchemicShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        static AlchemicShopContext()
        {
            Database.SetInitializer(new AlchemicShopInitializer());
        }

        //public AlchemicShopContext() : base("AlchemicShopConnection")
        //{
        //}

        public AlchemicShopContext(string connectionString)
           : base(connectionString)
        {
        }
    }
}
