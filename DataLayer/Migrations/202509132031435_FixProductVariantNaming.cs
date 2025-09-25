namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixProductVariantNaming : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Cart.CartItems", "VariantId", "Product.Product_Variants");
            DropForeignKey("Order.OrderItem", "VariantId", "Product.Product_Variants");
            DropForeignKey("Product.Product_Variants", "ProductId_Variant", "Product.Products");
            DropIndex("Order.OrderItem", new[] { "VariantId" });
            DropIndex("Product.Product_Variants", new[] { "ProductId_Variant" });
            DropIndex("Cart.CartItems", new[] { "CartId", "VariantId" });
            CreateTable(
                "Product.ProductVariants",
                c => new
                    {
                        VariantId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Color = c.String(maxLength: 100),
                        Size = c.String(maxLength: 100),
                        Volume = c.String(maxLength: 100),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VariantId)
                .ForeignKey("Product.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("Order.OrderItem", "VariantIdOrder", c => c.Int(nullable: false));
            AddColumn("Cart.CartItems", "VariantIdCart", c => c.Int(nullable: false));
            CreateIndex("Order.OrderItem", "VariantIdOrder");
            CreateIndex("Cart.CartItems", new[] { "CartId", "VariantIdCart" }, unique: true);
            AddForeignKey("Cart.CartItems", "VariantIdCart", "Product.ProductVariants", "VariantId");
            AddForeignKey("Order.OrderItem", "VariantIdOrder", "Product.ProductVariants", "VariantId", cascadeDelete: true);
            DropColumn("Order.OrderItem", "VariantId");
            DropColumn("Cart.CartItems", "VariantId");
            DropTable("Product.Product_Variants");
        }
        
        public override void Down()
        {
            CreateTable(
                "Product.Product_Variants",
                c => new
                    {
                        VariantId = c.Int(nullable: false, identity: true),
                        ProductId_Variant = c.Int(nullable: false),
                        Color = c.String(maxLength: 100),
                        Size = c.String(maxLength: 100),
                        Volume = c.String(maxLength: 100),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VariantId);
            
            AddColumn("Cart.CartItems", "VariantId", c => c.Int(nullable: false));
            AddColumn("Order.OrderItem", "VariantId", c => c.Int(nullable: false));
            DropForeignKey("Order.OrderItem", "VariantIdOrder", "Product.ProductVariants");
            DropForeignKey("Cart.CartItems", "VariantIdCart", "Product.ProductVariants");
            DropForeignKey("Product.ProductVariants", "ProductId", "Product.Products");
            DropIndex("Cart.CartItems", new[] { "CartId", "VariantIdCart" });
            DropIndex("Product.ProductVariants", new[] { "ProductId" });
            DropIndex("Order.OrderItem", new[] { "VariantIdOrder" });
            DropColumn("Cart.CartItems", "VariantIdCart");
            DropColumn("Order.OrderItem", "VariantIdOrder");
            DropTable("Product.ProductVariants");
            CreateIndex("Cart.CartItems", new[] { "CartId", "VariantId" }, unique: true);
            CreateIndex("Product.Product_Variants", "ProductId_Variant");
            CreateIndex("Order.OrderItem", "VariantId");
            AddForeignKey("Product.Product_Variants", "ProductId_Variant", "Product.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("Order.OrderItem", "VariantId", "Product.Product_Variants", "VariantId", cascadeDelete: true);
            AddForeignKey("Cart.CartItems", "VariantId", "Product.Product_Variants", "VariantId");
        }
    }
}
