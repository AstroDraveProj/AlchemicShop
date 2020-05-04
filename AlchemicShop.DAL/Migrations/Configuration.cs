namespace AlchemicShop.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AlchemicShop.DAL.AlchemicDbContext.AlchemicShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AlchemicShop.DAL.AlchemicDbContext.AlchemicShopContext context)
        {
        }
    }
}
