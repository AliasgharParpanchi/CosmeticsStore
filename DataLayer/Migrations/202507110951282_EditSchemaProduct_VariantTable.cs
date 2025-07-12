namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditSchemaProduct_VariantTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "Product_Variants.Product", newName: "Product_Variants");
            MoveTable(name: "Product_Variants.Product_Variants", newSchema: "Product");
        }
        
        public override void Down()
        {
            MoveTable(name: "Product.Product_Variants", newSchema: "Product_Variants");
            RenameTable(name: "Product_Variants.Product_Variants", newName: "Product");
        }
    }
}
