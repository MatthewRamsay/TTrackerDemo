using System.Data.Entity.Migrations;

namespace TTrackerDemo.Migrations
{
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'644823a8-c19b-4115-9dd2-fb9798b39555', N'guest@TTracker.com', 0, N'AAaqBWySMxWdlTBV1MXBYyba6GbDcrZy7a3JsPuxEFFlvpTXp3EpMKS9Gq9mru3uEg==', N'4e79ee88-650c-492f-aae6-d8f5107b0be8', NULL, 0, 0, NULL, 1, 0, N'guest@TTracker.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6840ee1c-89a1-4f6e-9afa-eab7a945846d', N'admin@TTracker.com', 0, N'ABQMVTJDh5mXNEXN4GbV7N5JaFLj/ndnyKKegr0oi3vG8frTPnrjSgBzLzysDf4HJA==', N'8bf60d59-e185-4d8f-873a-1b64a1970d37', NULL, 0, 0, NULL, 1, 0, N'admin@TTracker.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c8ab05b5-921f-42b5-aea3-6f5c6ce38997', N'Admin')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6840ee1c-89a1-4f6e-9afa-eab7a945846d', N'c8ab05b5-921f-42b5-aea3-6f5c6ce38997')
            ");
        }

        public override void Down()
        {
        }
    }
}