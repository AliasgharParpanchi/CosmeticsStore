namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserModelForPassword : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Log.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Log.Users", "Password", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
