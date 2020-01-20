namespace Titan2SettingsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRestirctions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Settings", "CreatedBy", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Settings", "CreatedBy", c => c.String());
        }
    }
}
