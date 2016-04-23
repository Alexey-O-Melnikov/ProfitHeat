namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManufacturerWindowProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WindowProfiles", "ManufacturerID", "dbo.Manufacturers");
            DropIndex("dbo.WindowProfiles", new[] { "ManufacturerID" });
            CreateTable(
                "dbo.ManufacturerWindowProfiles",
                c => new
                    {
                        ManufacturerWindowProfileID = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        TitleProfile = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerWindowProfileID);
            
            AddColumn("dbo.WindowProfiles", "Manufacturer_ManufacturerWindowProfileID", c => c.Int());
            CreateIndex("dbo.WindowProfiles", "Manufacturer_ManufacturerWindowProfileID");
            AddForeignKey("dbo.WindowProfiles", "Manufacturer_ManufacturerWindowProfileID", "dbo.ManufacturerWindowProfiles", "ManufacturerWindowProfileID");
            DropTable("dbo.Manufacturers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerID = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        TitleProfile = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerID);
            
            DropForeignKey("dbo.WindowProfiles", "Manufacturer_ManufacturerWindowProfileID", "dbo.ManufacturerWindowProfiles");
            DropIndex("dbo.WindowProfiles", new[] { "Manufacturer_ManufacturerWindowProfileID" });
            DropColumn("dbo.WindowProfiles", "Manufacturer_ManufacturerWindowProfileID");
            DropTable("dbo.ManufacturerWindowProfiles");
            CreateIndex("dbo.WindowProfiles", "ManufacturerID");
            AddForeignKey("dbo.WindowProfiles", "ManufacturerID", "dbo.Manufacturers", "ManufacturerID", cascadeDelete: true);
        }
    }
}
