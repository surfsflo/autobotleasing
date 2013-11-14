namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class nullableagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "Rating", c => c.Int());
            AlterColumn("dbo.Equipment", "Rating", c => c.Int());
            AlterColumn("dbo.Equipment", "PurchasePrice", c => c.Decimal(precision: 18, scale: 2));
        }

        public override void Down()
        {
            AlterColumn("dbo.Equipment", "PurchasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Equipment", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.UserProfile", "Rating");
        }
    }
}
