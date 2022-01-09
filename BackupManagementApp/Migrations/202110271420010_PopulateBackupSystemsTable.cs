namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBackupSystemsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BackupSystems (Id,Name) VALUES (1,'UNIX')");
            Sql("INSERT INTO BackupSystems (Id,Name) VALUES (2,'WINDOWS')");
            Sql("INSERT INTO BackupSystems (Id,Name) VALUES (3,'CAD-NAPP-DIFF')");
            Sql("INSERT INTO BackupSystems (Id,Name) VALUES (4,'CAD-NAPP-FULL-JOB1')");
            Sql("INSERT INTO BackupSystems (Id,Name) VALUES (5,'CAD-NAPP-FULL-JOB2')");
        }
        
        public override void Down()
        {
        }
    }
}
