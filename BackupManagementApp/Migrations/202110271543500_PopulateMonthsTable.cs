namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMonthsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Months (Id,Name) VALUES (1,'January')");
            Sql("INSERT INTO Months (Id,Name) VALUES (2,'February')");
            Sql("INSERT INTO Months (Id,Name) VALUES (3,'March')");
            Sql("INSERT INTO Months (Id,Name) VALUES (4,'April')");
            Sql("INSERT INTO Months (Id,Name) VALUES (5,'May')");
            Sql("INSERT INTO Months (Id,Name) VALUES (6,'June')");
            Sql("INSERT INTO Months (Id,Name) VALUES (7,'July')");
            Sql("INSERT INTO Months (Id,Name) VALUES (8,'August')");
            Sql("INSERT INTO Months (Id,Name) VALUES (9,'September')");
            Sql("INSERT INTO Months (Id,Name) VALUES (10,'October')");
            Sql("INSERT INTO Months (Id,Name) VALUES (11,'November')");
            Sql("INSERT INTO Months (Id,Name) VALUES (12,'December')");
        }
        
        public override void Down()
        {
        }
    }
}
