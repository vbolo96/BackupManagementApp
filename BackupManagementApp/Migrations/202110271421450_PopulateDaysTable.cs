namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDaysTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Days (Id,Name) VALUES (1,'Monday')");
            Sql("INSERT INTO Days (Id,Name) VALUES (2,'Tuesday')");
            Sql("INSERT INTO Days (Id,Name) VALUES (3,'Wednesday')");
            Sql("INSERT INTO Days (Id,Name) VALUES (4,'Thursday')");
            Sql("INSERT INTO Days (Id,Name) VALUES (5,'Friday')");
            Sql("INSERT INTO Days (Id,Name) VALUES (6,'Saturday')");
            Sql("INSERT INTO Days (Id,Name) VALUES (7,'Sunday')");          
        }
        
        public override void Down()
        {
        }
    }
}
