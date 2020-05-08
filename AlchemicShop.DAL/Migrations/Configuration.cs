namespace AlchemicShop.DAL.Migrations
{
    using AlchemicShop.DAL.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AlchemicShop.DAL.AlchemicDbContext.AlchemicShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AlchemicShop.DAL.AlchemicDbContext.AlchemicShopContext dbContext)
        {
            var user = new User
            {
                Login = "admin",
                Name = "Admin",
                Password = "admin",
                Role = 0
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
    }
}
