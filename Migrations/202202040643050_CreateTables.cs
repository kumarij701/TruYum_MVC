namespace TruYum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsFreeDelivered = c.Boolean(nullable: false),
                        Price = c.Int(nullable: false),
                        TypeOfItem = c.String(),
                        MenuItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItem", t => t.MenuItemId, cascadeDelete: true)
                .Index(t => t.MenuItemId);
            
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        MenuItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        TypeOfItem = c.String(),
                        IsFreeDelivered = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuItemId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "MenuItemId", "dbo.MenuItem");
            DropForeignKey("dbo.MenuItem", "CategoryId", "dbo.Category");
            DropIndex("dbo.MenuItem", new[] { "CategoryId" });
            DropIndex("dbo.Cart", new[] { "MenuItemId" });
            DropTable("dbo.Category");
            DropTable("dbo.MenuItem");
            DropTable("dbo.Cart");
        }
    }
}
