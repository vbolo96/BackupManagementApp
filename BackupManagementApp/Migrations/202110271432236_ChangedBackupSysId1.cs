namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBackupSysId1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tapes", "BackupTypes_Id", "dbo.BackupTypes");
            DropIndex("dbo.Tapes", new[] { "BackupTypes_Id" });
            RenameColumn(table: "dbo.Tapes", name: "BackupTypes_Id", newName: "BackupTypesId");
            AlterColumn("dbo.Tapes", "BackupTypesId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Tapes", "BackupTypesId");
            AddForeignKey("dbo.Tapes", "BackupTypesId", "dbo.BackupTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Tapes", "BackupTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tapes", "BackupTypeId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Tapes", "BackupTypesId", "dbo.BackupTypes");
            DropIndex("dbo.Tapes", new[] { "BackupTypesId" });
            AlterColumn("dbo.Tapes", "BackupTypesId", c => c.Byte());
            RenameColumn(table: "dbo.Tapes", name: "BackupTypesId", newName: "BackupTypes_Id");
            CreateIndex("dbo.Tapes", "BackupTypes_Id");
            AddForeignKey("dbo.Tapes", "BackupTypes_Id", "dbo.BackupTypes", "Id");
        }
    }
}
