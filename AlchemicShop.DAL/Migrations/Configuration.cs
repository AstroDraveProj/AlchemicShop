namespace AlchemicShop.DAL.Migrations
{
    using AlchemicShop.DAL.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AlchemicShop.DAL.AlchemicDbContext.AlchemicShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AlchemicDbContext.AlchemicShopContext dbContext)
        {
            var category = new Category { Name = "Poison" };
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();

            var product = new Product { Name = "Vitality", Amount = 20, Price = 20, Description = "Description", CategoryId = 1 };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            var userRole = new UserRole
            {
                Name = "Admin",
            };
            dbContext.UserRoles.Add(userRole);
            dbContext.SaveChanges();

            var user = new User
            {
                Name = "Lelouch",
                Login = "BritainKing",
                Password = "qwerty",
                UserRoleId = 1
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var order = new Order
            {
                SheduledDate = new DateTime(2020, 02, 03),
                Status = Status.InTransit,
                UserId = 1
            };

            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

            var orderProduct = new OrderProduct()
            {
                OrderId = 1,
                ProductId = 1,
                Amount = 2
            };

            dbContext.OrderProducts.Add(orderProduct);
            dbContext.SaveChanges();

        }
    }
}
