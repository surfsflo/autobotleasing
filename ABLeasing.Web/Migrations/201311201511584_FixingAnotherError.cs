namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingAnotherError : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipment", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Equipment", "Rating", c => c.Int());
            AlterColumn("dbo.Equipment", "Manufacturer", c => c.String(nullable: false));
            AlterColumn("dbo.Equipment", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Equipment", "RetailPrice", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Equipment", "PurchasePrice", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.Equipment", "ServiceContactId", c => c.Int());
            AlterColumn("dbo.Equipment", "SupplierContactId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipment", "SupplierContactID", c => c.Int());
            AlterColumn("dbo.Equipment", "ServiceContactID", c => c.Int());
            AlterColumn("dbo.Equipment", "PurchasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Equipment", "RetailPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Equipment", "Model", c => c.String());
            AlterColumn("dbo.Equipment", "Manufacturer", c => c.String());
            AlterColumn("dbo.Equipment", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Equipment", "Name", c => c.String());
        }
    }
}
