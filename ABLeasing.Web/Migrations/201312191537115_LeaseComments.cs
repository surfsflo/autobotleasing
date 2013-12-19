namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaseComments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "Lease_LeaseId", "dbo.Lease");
            DropIndex("dbo.Comment", new[] { "Lease_LeaseId" });
            AlterColumn("dbo.Comment", "Lease_LeaseId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Comment", "Lease_LeaseId", "dbo.Lease", "LeaseId", cascadeDelete: true);
            CreateIndex("dbo.Comment", "Lease_LeaseId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comment", new[] { "Lease_LeaseId" });
            DropForeignKey("dbo.Comment", "Lease_LeaseId", "dbo.Lease");
            AlterColumn("dbo.Comment", "Lease_LeaseId", c => c.Int());
            CreateIndex("dbo.Comment", "Lease_LeaseId");
            AddForeignKey("dbo.Comment", "Lease_LeaseId", "dbo.Lease", "LeaseId");
        }
    }
}
