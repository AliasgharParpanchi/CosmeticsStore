namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserTableEdit : DbMigration
    {
        public override void Up()
        {
            DropIndex("Log.Users", new[] { "Email" });
            AlterColumn("Log.Users", "Email", c => c.String(maxLength: 50));
            AlterColumn("Log.Users", "YearBirth", c => c.Int());
            AlterColumn("Log.Users", "MonthBirth", c => c.Int());
            AlterColumn("Log.Users", "DayBirth", c => c.Int());
            CreateIndex("Log.Users", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("Log.Users", new[] { "Email" });
            AlterColumn("Log.Users", "DayBirth", c => c.Int(nullable: false));
            AlterColumn("Log.Users", "MonthBirth", c => c.Int(nullable: false));
            AlterColumn("Log.Users", "YearBirth", c => c.Int(nullable: false));
            AlterColumn("Log.Users", "Email", c => c.String());
            CreateIndex("Log.Users", "Email", unique: true);
        }
    }
}
