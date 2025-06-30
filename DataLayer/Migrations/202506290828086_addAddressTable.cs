namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddressTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("Log.Users");
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Province = c.String(nullable: false, maxLength: 150),
                        City = c.String(nullable: false, maxLength: 150),
                        FullAddress = c.String(nullable: false, maxLength: 500),
                        Plaque = c.Int(nullable: false),
                        Unit = c.Int(nullable: false),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("Log.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            DropColumn("Log.Users", "Id");
            AddColumn("Log.Users", "UserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("Log.Users", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("Log.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Addresses", "UserId", "Log.Users");
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropPrimaryKey("Log.Users");
            DropColumn("Log.Users", "UserId");
            DropTable("dbo.Addresses");
            AddPrimaryKey("Log.Users", "Id");
        }
    }
}
