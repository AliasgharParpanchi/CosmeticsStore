namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditInterestsTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Interests", new[] { "ProductId" });
            DropIndex("dbo.Interests", new[] { "UserId" });
            CreateIndex("dbo.Interests", new[] { "UserId", "ProductId" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Interests", new[] { "UserId", "ProductId" });
            CreateIndex("dbo.Interests", "UserId");
            CreateIndex("dbo.Interests", "ProductId");
        }
    }
}
