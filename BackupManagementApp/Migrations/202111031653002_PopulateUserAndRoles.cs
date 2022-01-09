namespace BackupManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'280a03f6-461a-4cfa-a043-0b9c10731b3d', N'guest@dumpapplic.com', 0, N'AOoxvtc8rh5wkZa6860W/2OkFsTav7oiR1NRmHZqEZ0hFztRaxeLEP8FHqcLgMLmWQ==', N'3d25b455-5b6c-4e1f-8c9b-1621187da087', NULL, 0, 0, NULL, 1, 0, N'guest@dumpapplic.com')
                  INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'8f930e1c-f922-4f4c-87b8-0903f5662113', N'admin@dumpapplic.com', 0, N'AMahnsmzUPg9obprkNG1rcMervR4BUQCHLJRgdm9U3r3yLA/WBrF7WardOej1ctRGg==', N'02272901-eb2e-4932-a617-e703a483b91f', NULL, 0, 0, NULL, 1, 0, N'admin@dumpapplic.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7c9757ec-6126-40e4-a4b3-9d30009bee9a', N'CanManageTapes')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8f930e1c-f922-4f4c-87b8-0903f5662113', N'7c9757ec-6126-40e4-a4b3-9d30009bee9a') 
            ");
        }
        
        public override void Down()
        {
        }
    }
}
