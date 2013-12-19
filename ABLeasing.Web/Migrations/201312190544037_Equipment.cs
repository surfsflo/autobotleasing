namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Equipment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Equipment", "LeaseId", "dbo.Lease");
            DropIndex("dbo.Equipment", new[] { "LeaseId" });
            AddForeignKey("dbo.Equipment", "LeaseId", "dbo.Lease", "LeaseId", cascadeDelete: true);
            CreateIndex("dbo.Equipment", "LeaseId");
        }

        public override void Down()
        {
            DropIndex("dbo.Equipment", new[] { "LeaseId" });
            DropForeignKey("dbo.Equipment", "LeaseId", "dbo.Lease");
            CreateIndex("dbo.Equipment", "LeaseId");
            AddForeignKey("dbo.Equipment", "LeaseId", "dbo.Lease", "LeaseId");
        }
    }
}
