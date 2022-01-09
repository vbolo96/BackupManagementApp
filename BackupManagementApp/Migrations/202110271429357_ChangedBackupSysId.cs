namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBackupSysId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tapes", name: "SystemId", newName: "BackupSystemId");
            RenameIndex(table: "dbo.Tapes", name: "IX_SystemId", newName: "IX_BackupSystemId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tapes", name: "IX_BackupSystemId", newName: "IX_SystemId");
            RenameColumn(table: "dbo.Tapes", name: "BackupSystemId", newName: "SystemId");
        }
    }
}
