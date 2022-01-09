namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Days", "Name", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Days", "Name", c => c.String(nullable: false, maxLength: 12));
        }
    }
}
