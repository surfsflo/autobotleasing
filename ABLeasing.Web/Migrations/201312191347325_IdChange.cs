namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class IdChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfile", "PurchaseCooperative_PurchaseCooperativeID", "dbo.PurchaseCooperative");
            DropForeignKey("dbo.Comment", "PurchaseCooperative_PurchaseCooperativeID", "dbo.PurchaseCooperative");
            DropForeignKey("dbo.PurchaseCooperative", "PurchaseCooperativeID", "dbo.Lease");
            DropIndex("dbo.UserProfile", new[] { "PurchaseCooperative_PurchaseCooperativeID" });
            DropIndex("dbo.Comment", new[] { "PurchaseCooperative_PurchaseCooperativeID" });
            DropIndex("dbo.PurchaseCooperative", new[] { "PurchaseCooperativeID" });
            AlterColumn("dbo.UserProfile", "PurchaseCooperative_PurchaseCooperativeId", c => c.Int());
            AlterColumn("dbo.Comment", "PurchaseCooperative_PurchaseCooperativeId", c => c.Int());
            AlterColumn("dbo.PurchaseCooperative", "PurchaseCooperativeId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.PurchaseCooperative", new[] { "PurchaseCooperativeID" });
            AddPrimaryKey("dbo.PurchaseCooperative", "PurchaseCooperativeId");
            AddForeignKey("dbo.UserProfile", "PurchaseCooperative_PurchaseCooperativeId", "dbo.PurchaseCooperative", "PurchaseCooperativeId");
            AddForeignKey("dbo.Comment", "PurchaseCooperative_PurchaseCooperativeId", "dbo.PurchaseCooperative", "PurchaseCooperativeId");
            AddForeignKey("dbo.PurchaseCooperative", "PurchaseCooperativeId", "dbo.Lease", "LeaseId");
            CreateIndex("dbo.UserProfile", "PurchaseCooperative_PurchaseCooperativeId");
            CreateIndex("dbo.Comment", "PurchaseCooperative_PurchaseCooperativeId");
            CreateIndex("dbo.PurchaseCooperative", "PurchaseCooperativeId");
        }

        public override void Down()
        {
            DropIndex("dbo.PurchaseCooperative", new[] { "PurchaseCooperativeId" });
            DropIndex("dbo.Comment", new[] { "PurchaseCooperative_PurchaseCooperativeId" });
            DropIndex("dbo.UserProfile", new[] { "PurchaseCooperative_PurchaseCooperativeId" });
            DropForeignKey("dbo.PurchaseCooperative", "PurchaseCooperativeId", "dbo.Lease");
            DropForeignKey("dbo.Comment", "PurchaseCooperative_PurchaseCooperativeId", "dbo.PurchaseCooperative");
            DropForeignKey("dbo.UserProfile", "PurchaseCooperative_PurchaseCooperativeId", "dbo.PurchaseCooperative");
            DropPrimaryKey("dbo.PurchaseCooperative", new[] { "PurchaseCooperativeId" });
            AddPrimaryKey("dbo.PurchaseCooperative", "PurchaseCooperativeID");
            AlterColumn("dbo.PurchaseCooperative", "PurchaseCooperativeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Comment", "PurchaseCooperative_PurchaseCooperativeID", c => c.Int());
            AlterColumn("dbo.UserProfile", "PurchaseCooperative_PurchaseCooperativeID", c => c.Int());
            CreateIndex("dbo.PurchaseCooperative", "PurchaseCooperativeID");
            CreateIndex("dbo.Comment", "PurchaseCooperative_PurchaseCooperativeID");
            CreateIndex("dbo.UserProfile", "PurchaseCooperative_PurchaseCooperativeID");
            AddForeignKey("dbo.PurchaseCooperative", "PurchaseCooperativeID", "dbo.Lease", "LeaseId");
            AddForeignKey("dbo.Comment", "PurchaseCooperative_PurchaseCooperativeID", "dbo.PurchaseCooperative", "PurchaseCooperativeID");
            AddForeignKey("dbo.UserProfile", "PurchaseCooperative_PurchaseCooperativeID", "dbo.PurchaseCooperative", "PurchaseCooperativeID");
        }
    }
}
