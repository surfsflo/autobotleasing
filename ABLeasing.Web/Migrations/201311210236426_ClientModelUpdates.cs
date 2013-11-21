namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ClientModelUpdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfile", "Frequency", c => c.Int());
        }

        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "Frequency", c => c.String());
        }
    }
}
