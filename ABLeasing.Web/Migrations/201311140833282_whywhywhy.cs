namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whywhywhy : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Lease", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lease", "Description", c => c.String());
        }
    }
}
