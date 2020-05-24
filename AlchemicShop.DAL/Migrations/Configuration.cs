namespace AlchemicShop.DAL.Migrations
{
    using AlchemicShop.DAL.Entities;
    using AlchemicShop.Security.Encoding;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AlchemicShop.DAL.AlchemicDbContext.AlchemicShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AlchemicShop.DAL.AlchemicDbContext.AlchemicShopContext dbContext)
        {
            var admin = new User
            {
                Login = "admin",
                Name = "Admin",
                Password = CryptoProvider.GetMD5Hash("admin"),
                Role = Role.Admin
            };

            dbContext.Users.Add(admin);
            dbContext.SaveChanges();

            var user = new User
            {
                Login = "user",
                Name = "user",
                Password = CryptoProvider.GetMD5Hash("user"),
                Role = Role.User
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var user1 = new User
            {
                Login = "user1",
                Name = "user1",
                Password = CryptoProvider.GetMD5Hash("user1"),
                Role = Role.User
            };

            dbContext.Users.Add(user1);
            dbContext.SaveChanges();

            var user2 = new User
            {
                Login = "user2",
                Name = "user2",
                Password = CryptoProvider.GetMD5Hash("user2"),
                Role = Role.User
            };

            dbContext.Users.Add(user2);
            dbContext.SaveChanges();

            var user3 = new User
            {
                Login = "user3",
                Name = "user3",
                Password = CryptoProvider.GetMD5Hash("user3"),
                Role = Role.User
            };

            dbContext.Users.Add(user3);
            dbContext.SaveChanges();

            var category1 = new Category
            {
                Name = "Poison"
            };
            dbContext.Categories.Add(category1);
            dbContext.SaveChanges();

            var category2 = new Category
            {
                Name = "Potion"
            };
            dbContext.Categories.Add(category2);
            dbContext.SaveChanges();

            var category3 = new Category
            {
                Name = "Arcanum"
            };
            dbContext.Categories.Add(category3);
            dbContext.SaveChanges();

            var product1 = new Product()
            {
                Name = "Fortify Enchanting",
                Amount = 123,
                Description = "Ancestor Moth Wing * Blue Butterfly Wing Chaurus Hunter Antennae",
                Price = 50,
                CategoryId = 2
            };
            dbContext.Products.Add(product1);
            dbContext.SaveChanges();

            var product2 = new Product()
            {
                Name = "Deadly Poison",
                Amount = 13,
                Description = "Wing Chaurus Hunter Antennae Ancestor Moth Wing * Blue Butterfly ",
                Price = 100,
                CategoryId = 1
            };
            dbContext.Products.Add(product2);
            dbContext.SaveChanges();

            var product3 = new Product()
            {
                Name = "Arielle Phiencel",
                Amount = 123,
                Description = "Sadrith Mora: Wolverine Hall, Mages Guild",
                Price = 70,
                CategoryId = 3
            };
            dbContext.Products.Add(product3);
            dbContext.SaveChanges();

            var order1 = new Order
            {
                UserId = 2,
                SheduledDate = new DateTime(2020, 12, 25),
                Status = Status.Delivered,
                ClosedDate = new DateTime(2021, 12, 25)
            };
            dbContext.Orders.Add(order1);
            dbContext.SaveChanges();

            var orderproduct1 = new OrderProduct
            {
                Amount = 12,
                OrderId = 1,
                ProductId = 1
            };
            dbContext.OrderProducts.Add(orderproduct1);
            dbContext.SaveChanges();

            var orderproduct2 = new OrderProduct
            {
                Amount = 5,
                OrderId = 1,
                ProductId = 2
            };
            dbContext.OrderProducts.Add(orderproduct2);
            dbContext.SaveChanges();

            var order2 = new Order
            {
                UserId = 3,
                SheduledDate = new DateTime(2019, 11, 13),
                Status = Status.Delivered,
                ClosedDate = new DateTime(2022, 12, 26)
            };
            dbContext.Orders.Add(order2);
            dbContext.SaveChanges();

            var orderproduct3 = new OrderProduct
            {
                Amount = 32,
                OrderId = 2,
                ProductId = 2
            };
            dbContext.OrderProducts.Add(orderproduct3);
            dbContext.SaveChanges();

            var orderproduct4 = new OrderProduct
            {
                Amount = 4,
                OrderId = 2,
                ProductId = 3
            };
            dbContext.OrderProducts.Add(orderproduct4);
            dbContext.SaveChanges();

            var order3 = new Order
            {
                UserId = 4,
                SheduledDate = new DateTime(2017, 03, 10),
                Status = Status.Delivered,
                ClosedDate = new DateTime(2017, 05, 02)
            };
            dbContext.Orders.Add(order3);
            dbContext.SaveChanges();

            var orderproduct5 = new OrderProduct
            {
                Amount = 7,
                OrderId = 3,
                ProductId = 1
            };
            dbContext.OrderProducts.Add(orderproduct5);
            dbContext.SaveChanges();

            var orderproduct6 = new OrderProduct
            {
                Amount = 6,
                OrderId = 3,
                ProductId = 3
            };
            dbContext.OrderProducts.Add(orderproduct6);
            dbContext.SaveChanges();
        }
    }
}
