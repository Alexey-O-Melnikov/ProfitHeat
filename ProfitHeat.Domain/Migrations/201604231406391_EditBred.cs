namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBred : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ManufacturerWindowProfiles", "MarkProfileID", "dbo.MarkProfiles");
            DropForeignKey("dbo.WindowProfiles", "Manufacturer_ManufacturerWindowProfileID", "dbo.ManufacturerWindowProfiles");
            DropIndex("dbo.ManufacturerWindowProfiles", new[] { "MarkProfileID" });
            DropIndex("dbo.WindowProfiles", new[] { "Manufacturer_ManufacturerWindowProfileID" });
            AddColumn("dbo.ManufacturerWindowProfiles", "TitleCompany", c => c.String());
            AddColumn("dbo.MarkProfiles", "ManufacturerWindowProfileID", c => c.Int(nullable: false));
            AddColumn("dbo.MarkProfiles", "TitleMark", c => c.String());
            AddColumn("dbo.WindowProfiles", "MarkProfileID", c => c.Int(nullable: false));
            CreateIndex("dbo.MarkProfiles", "ManufacturerWindowProfileID");
            CreateIndex("dbo.WindowProfiles", "MarkProfileID");
            AddForeignKey("dbo.MarkProfiles", "ManufacturerWindowProfileID", "dbo.ManufacturerWindowProfiles", "ManufacturerWindowProfileID", cascadeDelete: true);
            AddForeignKey("dbo.WindowProfiles", "MarkProfileID", "dbo.MarkProfiles", "MarkProfileID", cascadeDelete: true);
            DropColumn("dbo.ManufacturerWindowProfiles", "MarkProfileID");
            DropColumn("dbo.ManufacturerWindowProfiles", "Company");
            DropColumn("dbo.MarkProfiles", "Title");
            DropColumn("dbo.WindowProfiles", "ManufacturerID");
            DropColumn("dbo.WindowProfiles", "Manufacturer_ManufacturerWindowProfileID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WindowProfiles", "Manufacturer_ManufacturerWindowProfileID", c => c.Int());
            AddColumn("dbo.WindowProfiles", "ManufacturerID", c => c.Int(nullable: false));
            AddColumn("dbo.MarkProfiles", "Title", c => c.String());
            AddColumn("dbo.ManufacturerWindowProfiles", "Company", c => c.String());
            AddColumn("dbo.ManufacturerWindowProfiles", "MarkProfileID", c => c.Int(nullable: false));
            DropForeignKey("dbo.WindowProfiles", "MarkProfileID", "dbo.MarkProfiles");
            DropForeignKey("dbo.MarkProfiles", "ManufacturerWindowProfileID", "dbo.ManufacturerWindowProfiles");
            DropIndex("dbo.WindowProfiles", new[] { "MarkProfileID" });
            DropIndex("dbo.MarkProfiles", new[] { "ManufacturerWindowProfileID" });
            DropColumn("dbo.WindowProfiles", "MarkProfileID");
            DropColumn("dbo.MarkProfiles", "TitleMark");
            DropColumn("dbo.MarkProfiles", "ManufacturerWindowProfileID");
            DropColumn("dbo.ManufacturerWindowProfiles", "TitleCompany");
            CreateIndex("dbo.WindowProfiles", "Manufacturer_ManufacturerWindowProfileID");
            CreateIndex("dbo.ManufacturerWindowProfiles", "MarkProfileID");
            AddForeignKey("dbo.WindowProfiles", "Manufacturer_ManufacturerWindowProfileID", "dbo.ManufacturerWindowProfiles", "ManufacturerWindowProfileID");
            AddForeignKey("dbo.ManufacturerWindowProfiles", "MarkProfileID", "dbo.MarkProfiles", "MarkProfileID", cascadeDelete: true);
        }
    }
}
