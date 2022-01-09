namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNullableWeekAndMonthIDForTapeInCaseTapeIsForDailyBackup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tapes", "MonthId", "dbo.Months");
            DropForeignKey("dbo.Tapes", "WeekId", "dbo.Weeks");
            DropIndex("dbo.Tapes", new[] { "WeekId" });
            DropIndex("dbo.Tapes", new[] { "MonthId" });
            AlterColumn("dbo.Tapes", "WeekId", c => c.Byte());
            AlterColumn("dbo.Tapes", "MonthId", c => c.Byte());
            CreateIndex("dbo.Tapes", "WeekId");
            CreateIndex("dbo.Tapes", "MonthId");
            AddForeignKey("dbo.Tapes", "MonthId", "dbo.Months", "Id");
            AddForeignKey("dbo.Tapes", "WeekId", "dbo.Weeks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tapes", "WeekId", "dbo.Weeks");
            DropForeignKey("dbo.Tapes", "MonthId", "dbo.Months");
            DropIndex("dbo.Tapes", new[] { "MonthId" });
            DropIndex("dbo.Tapes", new[] { "WeekId" });
            AlterColumn("dbo.Tapes", "MonthId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Tapes", "WeekId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Tapes", "MonthId");
            CreateIndex("dbo.Tapes", "WeekId");
            AddForeignKey("dbo.Tapes", "WeekId", "dbo.Weeks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tapes", "MonthId", "dbo.Months", "Id", cascadeDelete: true);
        }
    }
}
