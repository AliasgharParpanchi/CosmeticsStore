namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditProductsAndProducts_CategoriesTable : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Products_Categories", newSchema: "Product");
            MoveTable(name: "dbo.Products", newSchema: "Product");
            DropForeignKey("dbo.Products_Categories", "CategoryId", "Product.Categories");
            CreateIndex("Product.Products", "ProductCode", unique: true);
            AddForeignKey("Product.Products_Categories", "CategoryId", "Product.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("Product.Products_Categories", "CategoryId", "Product.Categories");
            DropIndex("Product.Products", new[] { "ProductCode" });
            AddForeignKey("dbo.Products_Categories", "CategoryId", "Product.Categories", "CategoryId", cascadeDelete: true);
            MoveTable(name: "Product.Products", newSchema: "dbo");
            MoveTable(name: "Product.Products_Categories", newSchema: "dbo");
        }
    }
}
