namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Log.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 150),
                        LastName = c.String(maxLength: 150),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 150),
                        NationalCode = c.String(maxLength: 10),
                        Phone = c.String(maxLength: 11),
                        YearBirth = c.Int(nullable: false),
                        MonthBirth = c.Int(nullable: false),
                        DayBirth = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("Log.Users", new[] { "Email" });
            DropIndex("Log.Users", new[] { "UserName" });
            DropTable("Log.Users");
        }
    }
}
