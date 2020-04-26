namespace AlchemicShop.DAL.Migrations
{
    using AlchemicShop.DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AlchemicShop.DAL.AlchemicDbContext.AlchemicShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AlchemicShop.DAL.AlchemicDbContext.AlchemicShopContext dbContext)
        {
            var category = new Category { Id = 1, Name = "Poison" };
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();

            var product = new Product { Id = 1, Name = "Vitality", Amount = 20, Price = 20, Description = "Description", CategoryId = 1 };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            //var orderProduct = new OrderProduct { Id = 1, OrderId = 1, ProductId = 1, Amount = 10 };
            //List<OrderProduct> orderProducts = new List<OrderProduct>();
            ////orderProducts.Add(orderProduct);

            //var user = new User
            //{
            //    Id = 1,
            //    Name = "Lelouch",
            //    Login = "BritainKing",
            //    Password = "qwerty",
            //    IsAdmin = false
            //};

            //var order = new Order
            //{
            //    Id = 1,
            //    SheduledDate = new DateTime(2020, 02, 03),
            //    Status = Status.InTransit,
            //    UserId = 1
            //};
            //List<Order> orders = new List<Order>();
            ////orders.Add(order);
            ////user.Orders = orders;


            //dbContext.Users.Add(user);
            //dbContext.SaveChanges();

            //dbContext.Orders.Add(order);
            //dbContext.SaveChanges();

            //dbContext.OrderProducts.Add(orderProduct);
            //dbContext.SaveChanges();





        }
    }
}
