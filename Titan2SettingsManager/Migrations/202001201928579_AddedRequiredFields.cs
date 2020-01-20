namespace Titan2SettingsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Settings", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Settings", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Settings", "Value", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Settings", "Value", c => c.String());
            AlterColumn("dbo.Settings", "Description", c => c.String());
            AlterColumn("dbo.Settings", "Name", c => c.String());
        }
    }
}
