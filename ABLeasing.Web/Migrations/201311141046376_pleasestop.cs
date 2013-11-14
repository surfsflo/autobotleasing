namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pleasestop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfile", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "Rating", c => c.Int());
        }
    }
}
