namespace AlchemicShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_UserRole_tbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserRoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "UserRoleId");
            AddForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "IsAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropColumn("dbo.Users", "UserRoleId");
            DropTable("dbo.UserRoles");
        }
    }
}
