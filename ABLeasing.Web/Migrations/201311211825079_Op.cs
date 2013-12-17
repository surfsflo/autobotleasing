namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Op : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lease", "Name", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Lease", "Name", c => c.String());
        }
    }
}
