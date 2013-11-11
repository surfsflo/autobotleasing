namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseCooperatives",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        lease_LeaseId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Leases", t => t.lease_LeaseId)
                .Index(t => t.lease_LeaseId);
            
            CreateTable(
                "dbo.Leases",
                c => new
                    {
                        LeaseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Equipment_EquipmentId = c.Int(),
                    })
                .PrimaryKey(t => t.LeaseId)
                .ForeignKey("dbo.Equipments", t => t.Equipment_EquipmentId)
                .Index(t => t.Equipment_EquipmentId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.EquipmentId);
            
            AddColumn("dbo.UserProfile", "PurchaseCooperative_ID", c => c.Int());
            AddForeignKey("dbo.UserProfile", "PurchaseCooperative_ID", "dbo.PurchaseCooperatives", "ID");
            CreateIndex("dbo.UserProfile", "PurchaseCooperative_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Leases", new[] { "Equipment_EquipmentId" });
            DropIndex("dbo.PurchaseCooperatives", new[] { "lease_LeaseId" });
            DropIndex("dbo.UserProfile", new[] { "PurchaseCooperative_ID" });
            DropForeignKey("dbo.Leases", "Equipment_EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.PurchaseCooperatives", "lease_LeaseId", "dbo.Leases");
            DropForeignKey("dbo.UserProfile", "PurchaseCooperative_ID", "dbo.PurchaseCooperatives");
            DropColumn("dbo.UserProfile", "PurchaseCooperative_ID");
            DropTable("dbo.Equipments");
            DropTable("dbo.Leases");
            DropTable("dbo.PurchaseCooperatives");
        }
    }
}
