namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateWeeksTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Weeks (Id,Name) VALUES (1,'Week 1')");
            Sql("INSERT INTO Weeks (Id,Name) VALUES (2,'Week 2')");
            Sql("INSERT INTO Weeks (Id,Name) VALUES (3,'Week 3')");
            Sql("INSERT INTO Weeks (Id,Name) VALUES (4,'Week 4')");
        }
        
        public override void Down()
        {
        }
    }
}
