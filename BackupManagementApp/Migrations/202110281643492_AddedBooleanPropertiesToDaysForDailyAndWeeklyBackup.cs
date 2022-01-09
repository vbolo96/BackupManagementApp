namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBooleanPropertiesToDaysForDailyAndWeeklyBackup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Days", "IsDailyTape", c => c.Boolean(nullable: false));
            AddColumn("dbo.Days", "IsWeeklyTape", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Days", "IsWeeklyTape");
            DropColumn("dbo.Days", "IsDailyTape");
        }
    }
}
