namespace NutritionWatcher2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeModels1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignmentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsumedGramm = c.Int(nullable: false),
                        Consumption_Id = c.Int(nullable: false),
                        Food_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConsumptionModels", t => t.Consumption_Id, cascadeDelete: true)
                .ForeignKey("dbo.FoodModels", t => t.Food_Id, cascadeDelete: true)
                .Index(t => t.Consumption_Id)
                .Index(t => t.Food_Id);
            
            CreateTable(
                "dbo.ConsumptionModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(nullable: false),
                        Time = c.String(nullable: false),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.FoodModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ProteinAmount = c.Single(nullable: false),
                        FatAmount = c.Single(nullable: false),
                        HydrocarbonateAmount = c.Single(nullable: false),
                        Gramm = c.Int(nullable: false),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignmentModels", "Food_Id", "dbo.FoodModels");
            DropForeignKey("dbo.FoodModels", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AssignmentModels", "Consumption_Id", "dbo.ConsumptionModels");
            DropForeignKey("dbo.ConsumptionModels", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FoodModels", new[] { "Owner_Id" });
            DropIndex("dbo.ConsumptionModels", new[] { "Owner_Id" });
            DropIndex("dbo.AssignmentModels", new[] { "Food_Id" });
            DropIndex("dbo.AssignmentModels", new[] { "Consumption_Id" });
            DropTable("dbo.FoodModels");
            DropTable("dbo.ConsumptionModels");
            DropTable("dbo.AssignmentModels");
        }
    }
}
