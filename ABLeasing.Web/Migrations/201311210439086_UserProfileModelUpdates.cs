namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UserProfileModelUpdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfile", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserProfile", "Name", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "Name", c => c.String());
            AlterColumn("dbo.UserProfile", "Email", c => c.String());
        }
    }
}
