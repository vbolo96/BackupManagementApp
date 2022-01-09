namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTapeIdToIntInOrderToFixTheProgram : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tapes");
            AlterColumn("dbo.Tapes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tapes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Tapes");
            AlterColumn("dbo.Tapes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Tapes", "Id");
        }
    }
}
