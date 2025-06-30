namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editAddressTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "UserId", "Log.Users");
            AddForeignKey("dbo.Addresses", "UserId", "Log.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "UserId", "Log.Users");
            AddForeignKey("dbo.Addresses", "UserId", "Log.Users", "UserId");
        }
    }
}
