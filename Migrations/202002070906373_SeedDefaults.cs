namespace NutritionWatcher2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDefaults : DbMigration
    {
        public override void Up()
        {
            // seed roles
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES " +
                "(N'f8deeba2-1912-4038-992e-df70bb0378c3', N'Admin'), " +
                "(N'47f1b03c-716b-4a50-a96d-44b3ef96c0f3', N'Guest'), " +
                "(N'a7ee7d34-eeb9-4abc-aad5-22911ad7cfb0', N'Member');");

            // seed users
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES " +
                "(N'26819248-d7dd-4ab9-9c73-2408b0c9cbec', N'guest@nutrition.com', 0, N'AMIQFZRF4RnSYPm23VMH9SkSrDcnY9wXIVb0sNr6TbdGEo8p83XcPYod+vDU2BTKOw==', N'c01cc2a2-51b5-49bd-9653-f90d60858c3a', NULL, 0, 0, NULL, 1, 0, N'guest@nutrition.com'), " +
                "(N'366bbad6-878e-45eb-920b-e5e5e9863d11', N'admin@nutrition.com', 0, N'AFFAOB4p+Wcu5ctb5n8N9e6h8r1Q62hcon1yfig5F0WA4kBxbpeOKSizuIAvfTAQsw==', N'a0f7032a-6a25-4721-9d5b-ac32dbb829fa', NULL, 0, 0, NULL, 1, 0, N'admin@nutrition.com'), " +
                "(N'af68351f-7013-4c87-bfd8-8c7a8552e717', N'member@nutrition.com', 0, N'ANvSZ6BJjt/iYm9vMOBmm2QiCHDwFdu+mb5bkWXdcUAyCiuAdjV/T+2TewpEgS5bkA==', N'd27cab95-96ae-445a-a3b8-ac40d1e3c524', NULL, 0, 0, NULL, 1, 0, N'member@nutrition.com')");

            // seed user-roles
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES " +
                "(N'26819248-d7dd-4ab9-9c73-2408b0c9cbec', N'47f1b03c-716b-4a50-a96d-44b3ef96c0f3'), " +
                "(N'af68351f-7013-4c87-bfd8-8c7a8552e717', N'a7ee7d34-eeb9-4abc-aad5-22911ad7cfb0'), " +
                "(N'366bbad6-878e-45eb-920b-e5e5e9863d11', N'f8deeba2-1912-4038-992e-df70bb0378c3')");

            // seed default foods
            Sql($"INSERT INTO [dbo].[FoodModels] ([Name], [ProteinAmount], [FatAmount], [HydrocarbonateAmount], [Gramm]) VALUES { Properties.Resources.SqlValuesFirstHalf }");
            Sql($"INSERT INTO [dbo].[FoodModels] ([Name], [ProteinAmount], [FatAmount], [HydrocarbonateAmount], [Gramm]) VALUES { Properties.Resources.SqlValuesSecondHalf }");
        }
        
        public override void Down()
        {
        }
    }
}
