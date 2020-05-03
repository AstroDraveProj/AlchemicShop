using AlchemicShop.DAL.Entities;
using System.Data.Entity;

namespace AlchemicShop.DAL.AlchemicDbContext
{
    class AlchemicShopInitializer : DropCreateDatabaseAlways<AlchemicShopContext>
    {
        protected override void Seed(AlchemicShopContext dbContext)
        {
            var category = new Category { Name = "Poison" };
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }
    }
}