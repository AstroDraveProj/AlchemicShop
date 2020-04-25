using AlchemicShop.DAL.Entities;
using System;
using System.Data.Entity;

namespace AlchemicShop.DAL.AlchemicDbContext
{
    class AlchemicShopInitializer : DropCreateDatabaseIfModelChanges<AlchemicShopContext>
    {
        protected override void Seed(AlchemicShopContext dbContext)
        {
            var category = new Category { Name = "Poison" };
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();

            var product = new Product { Name = "Vitality", Amount = 20, Price = 20, Description = "Description", CategoryId = 1 };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            //var order = new Order { SheduledDate = new DateTime(2020, 02, 03), Status = Status.InTransit };
            //dbContext.Orders.Add(order);
            //dbContext.SaveChanges();

            //var orderProduct = new OrderProduct { OrderId = 1, ProductId = 1, Amount = 10 };
            //dbContext.OrderProducts.Add(orderProduct);
            //dbContext.SaveChanges();

            //var user = new User { Name = "Lelouch", Login = "BritainKing", Password = "qwerty", IsAdmin = false, OrderId = 1 };
            //dbContext.Users.Add(user);
            //dbContext.SaveChanges();
        }
    }
}