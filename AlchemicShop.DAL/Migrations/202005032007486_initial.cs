namespace AlchemicShop.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 40),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CategoryId = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 40),
                    Amount = c.Int(nullable: false),
                    Description = c.String(),
                    Price = c.Single(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.OrderProducts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    OrderId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    Amount = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => new { t.OrderId, t.ProductId }, unique: true, name: "IX_OrderProduct");

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CustomerId = c.Int(nullable: false),
                    SheduledDate = c.DateTime(nullable: false),
                    ClosedDate = c.DateTime(),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Role = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 40),
                    Login = c.String(nullable: false, maxLength: 20),
                    Password = c.String(nullable: false, maxLength: 40),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true);

        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.OrderProducts", "IX_OrderProduct");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
