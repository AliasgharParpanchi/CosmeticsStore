namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInterestTableAndEditTables : DbMigration
    {
        public override void Up()
        {
            DropIndex("Product.Products_Categories", new[] { "ProductId" });
            DropIndex("Product.Products_Categories", new[] { "CategoryId" });
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        InterestId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InterestId)
                .ForeignKey("Product.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Log.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            AddColumn("Product.Comments", "Created", c => c.DateTime(nullable: false));
            AddColumn("Product.Comments", "IsApproved", c => c.Boolean(nullable: false));
            CreateIndex("Product.Products_Categories", new[] { "CategoryId", "ProductId" }, unique: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Interests", "UserId", "Log.Users");
            DropForeignKey("dbo.Interests", "ProductId", "Product.Products");
            DropIndex("dbo.Interests", new[] { "ProductId" });
            DropIndex("dbo.Interests", new[] { "UserId" });
            DropIndex("Product.Products_Categories", new[] { "CategoryId", "ProductId" });
            DropColumn("Product.Comments", "IsApproved");
            DropColumn("Product.Comments", "Created");
            DropTable("dbo.Interests");
            CreateIndex("Product.Products_Categories", "CategoryId");
            CreateIndex("Product.Products_Categories", "ProductId");
        }
    }
}
