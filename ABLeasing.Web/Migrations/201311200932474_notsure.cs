namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notsure : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipment", "Manufacturer", c => c.String(nullable: false));
            AlterColumn("dbo.Equipment", "Model", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipment", "Model", c => c.String());
            AlterColumn("dbo.Equipment", "Manufacturer", c => c.String());
        }
    }
}
