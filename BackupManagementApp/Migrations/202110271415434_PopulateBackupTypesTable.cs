namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBackupTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BackupTypes (Id,Name) VALUES (1,'Daily Backup')");
            Sql("INSERT INTO BackupTypes (Id,Name) VALUES (2,'Weekly Backup')");
            Sql("INSERT INTO BackupTypes (Id,Name) VALUES (3,'Monthly Backup')");
            Sql("INSERT INTO BackupTypes (Id,Name) VALUES (4,'Yearly Backup')");
        }
        
        public override void Down()
        {
        }
    }
}
