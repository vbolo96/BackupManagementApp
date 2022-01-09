namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateHistoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarCode = c.String(maxLength: 8),
                        BackupSystemId = c.Byte(nullable: false),
                        BackupTypesId = c.Byte(nullable: false),
                        DayId = c.Byte(nullable: false),
                        WeekId = c.Byte(),
                        MonthId = c.Byte(),
                        Details = c.String(maxLength: 255),
                        CheckedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BackupSystems", t => t.BackupSystemId, cascadeDelete: true)
                .ForeignKey("dbo.BackupTypes", t => t.BackupTypesId, cascadeDelete: true)
                .ForeignKey("dbo.Days", t => t.DayId, cascadeDelete: true)
                .ForeignKey("dbo.Months", t => t.MonthId)
                .ForeignKey("dbo.Weeks", t => t.WeekId)
                .Index(t => t.BackupSystemId)
                .Index(t => t.BackupTypesId)
                .Index(t => t.DayId)
                .Index(t => t.WeekId)
                .Index(t => t.MonthId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Histories", "WeekId", "dbo.Weeks");
            DropForeignKey("dbo.Histories", "MonthId", "dbo.Months");
            DropForeignKey("dbo.Histories", "DayId", "dbo.Days");
            DropForeignKey("dbo.Histories", "BackupTypesId", "dbo.BackupTypes");
            DropForeignKey("dbo.Histories", "BackupSystemId", "dbo.BackupSystems");
            DropIndex("dbo.Histories", new[] { "MonthId" });
            DropIndex("dbo.Histories", new[] { "WeekId" });
            DropIndex("dbo.Histories", new[] { "DayId" });
            DropIndex("dbo.Histories", new[] { "BackupTypesId" });
            DropIndex("dbo.Histories", new[] { "BackupSystemId" });
            DropTable("dbo.Histories");
        }
    }
}
