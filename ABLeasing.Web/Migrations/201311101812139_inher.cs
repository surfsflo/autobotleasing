namespace ABLeasing.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inher : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfile", "ClientId");
            DropColumn("dbo.UserProfile", "OperatorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfile", "OperatorId", c => c.Int());
            AddColumn("dbo.UserProfile", "ClientId", c => c.Int());
        }
    }
}
