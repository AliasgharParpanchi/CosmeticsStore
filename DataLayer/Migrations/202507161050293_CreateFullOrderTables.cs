namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFullOrderTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Order.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        OrderCode = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("Order.OrderStatus", t => t.OrderStatusId, cascadeDelete: true)
                .ForeignKey("Log.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.OrderStatusId)
                .Index(t => t.OrderCode, unique: true);
            
            CreateTable(
                "Order.OrderItem",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("Order.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("Product.Product_Variants", t => t.VariantId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.VariantId);
            
            CreateTable(
                "Order.OrderStatus",
                c => new
                    {
                        OrderStatusId = c.Int(nullable: false, identity: true),
                        StatusTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Order.Orders", "UserId", "Log.Users");
            DropForeignKey("Order.Orders", "OrderStatusId", "Order.OrderStatus");
            DropForeignKey("Order.OrderItem", "VariantId", "Product.Product_Variants");
            DropForeignKey("Order.OrderItem", "OrderId", "Order.Orders");
            DropForeignKey("Order.Orders", "AddressId", "dbo.Addresses");
            DropIndex("Order.OrderItem", new[] { "VariantId" });
            DropIndex("Order.OrderItem", new[] { "OrderId" });
            DropIndex("Order.Orders", new[] { "OrderCode" });
            DropIndex("Order.Orders", new[] { "OrderStatusId" });
            DropIndex("Order.Orders", new[] { "AddressId" });
            DropIndex("Order.Orders", new[] { "UserId" });
            DropTable("Order.OrderStatus");
            DropTable("Order.OrderItem");
            DropTable("Order.Orders");
        }
    }
}
