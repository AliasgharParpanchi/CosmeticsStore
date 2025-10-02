namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("Log.Users", new[] { "UserName" });
            DropColumn("Log.Users", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("Log.Users", "UserName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("Log.Users", "UserName", unique: true);
        }
    }
}
