namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCartItemTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Cart.CartItems", "VariantId", "Product.Product_Variants");
            AddForeignKey("Cart.CartItems", "VariantId", "Product.Product_Variants", "VariantId");
        }
        
        public override void Down()
        {
            DropForeignKey("Cart.CartItems", "VariantId", "Product.Product_Variants");
            AddForeignKey("Cart.CartItems", "VariantId", "Product.Product_Variants", "VariantId", cascadeDelete: true);
        }
    }
}
