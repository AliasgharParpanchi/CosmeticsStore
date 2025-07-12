namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCommentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Product.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Commnet = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("Product.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("Log.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Product.Comments", "UserId", "Log.Users");
            DropForeignKey("Product.Comments", "ProductId", "Product.Products");
            DropIndex("Product.Comments", new[] { "ProductId" });
            DropIndex("Product.Comments", new[] { "UserId" });
            DropTable("Product.Comments");
        }
    }
}
