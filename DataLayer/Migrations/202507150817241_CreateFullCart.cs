namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFullCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Cart.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("Log.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId, unique: true);
            
            CreateTable(
                "Cart.CartItems",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("Cart.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("Product.Product_Variants", t => t.VariantId, cascadeDelete: true)
                .Index(t => new { t.CartId, t.VariantId }, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Cart.Carts", "UserId", "Log.Users");
            DropForeignKey("Cart.CartItems", "VariantId", "Product.Product_Variants");
            DropForeignKey("Cart.CartItems", "CartId", "Cart.Carts");
            DropIndex("Cart.CartItems", new[] { "CartId", "VariantId" });
            DropIndex("Cart.Carts", new[] { "UserId" });
            DropTable("Cart.CartItems");
            DropTable("Cart.Carts");
        }
    }
}
