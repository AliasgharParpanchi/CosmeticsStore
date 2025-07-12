namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("Product.Products", "ImageName1", c => c.String());
            AddColumn("Product.Products", "ImageName2", c => c.String());
            AddColumn("Product.Products", "ImageName3", c => c.String());
            AddColumn("Product.Products", "ImageName4", c => c.String());
            AddColumn("Product.Products", "ImageName5", c => c.String());
            AddColumn("Product.Products", "Price", c => c.Int(nullable: false));
            AddColumn("Product.Products", "DiscountPercent", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("Product.Products", "ImageName");
        }
        
        public override void Down()
        {
            AddColumn("Product.Products", "ImageName", c => c.String());
            DropColumn("Product.Products", "DiscountPercent");
            DropColumn("Product.Products", "Price");
            DropColumn("Product.Products", "ImageName5");
            DropColumn("Product.Products", "ImageName4");
            DropColumn("Product.Products", "ImageName3");
            DropColumn("Product.Products", "ImageName2");
            DropColumn("Product.Products", "ImageName1");
        }
    }
}
