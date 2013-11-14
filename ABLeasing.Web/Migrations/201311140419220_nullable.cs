namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lease", "Description", c => c.String());
            AlterColumn("dbo.Lease", "PrincipalAmount", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.Lease", "InterestRate", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.Lease", "ProfitShareRate", c => c.Decimal(storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lease", "ProfitShareRate", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Lease", "InterestRate", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Lease", "PrincipalAmount", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.Lease", "Description");
        }
    }
}
