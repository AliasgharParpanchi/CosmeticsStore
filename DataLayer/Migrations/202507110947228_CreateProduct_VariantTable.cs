namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProduct_VariantTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Product_Variants.Product",
                c => new
                    {
                        VariantId = c.Int(nullable: false, identity: true),
                        ProductId_Variant = c.Int(nullable: false),
                        Color = c.String(maxLength: 100),
                        Size = c.String(maxLength: 100),
                        Volume = c.String(maxLength: 100),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VariantId)
                .ForeignKey("Product.Products", t => t.ProductId_Variant, cascadeDelete: true)
                .Index(t => t.ProductId_Variant);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Product_Variants.Product", "ProductId_Variant", "Product.Products");
            DropIndex("Product_Variants.Product", new[] { "ProductId_Variant" });
            DropTable("Product_Variants.Product");
        }
    }
}
