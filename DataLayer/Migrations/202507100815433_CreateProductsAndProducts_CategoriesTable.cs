namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductsAndProducts_CategoriesTable : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Categories", newSchema: "Product");
            CreateTable(
                "dbo.Products_Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Product.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 300),
                        ProductCode = c.String(maxLength: 200),
                        Description = c.String(),
                        HowToUse = c.String(),
                        ImageName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products_Categories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products_Categories", "CategoryId", "Product.Categories");
            DropIndex("dbo.Products_Categories", new[] { "CategoryId" });
            DropIndex("dbo.Products_Categories", new[] { "ProductId" });
            DropTable("dbo.Products");
            DropTable("dbo.Products_Categories");
            MoveTable(name: "Product.Categories", newSchema: "dbo");
        }
    }
}
