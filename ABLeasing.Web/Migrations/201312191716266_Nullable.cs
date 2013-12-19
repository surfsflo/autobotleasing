namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseCooperative", "AmountFinanced", c => c.Decimal(storeType: "money"));
        }

        public override void Down()
        {
            AlterColumn("dbo.PurchaseCooperative", "AmountFinanced", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
