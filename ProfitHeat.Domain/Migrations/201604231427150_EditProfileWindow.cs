namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditProfileWindow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MarkProfiles", "ManufacturerWindowProfileID", "dbo.ManufacturerWindowProfiles");
            DropForeignKey("dbo.WindowProfiles", "MarkProfileID", "dbo.MarkProfiles");
            DropIndex("dbo.MarkProfiles", new[] { "ManufacturerWindowProfileID" });
            DropIndex("dbo.WindowProfiles", new[] { "MarkProfileID" });
            AddColumn("dbo.WindowProfiles", "ManufacturerWindowProfileID", c => c.Int(nullable: false));
            AddColumn("dbo.WindowProfiles", "TitleMark", c => c.String());
            CreateIndex("dbo.WindowProfiles", "ManufacturerWindowProfileID");
            AddForeignKey("dbo.WindowProfiles", "ManufacturerWindowProfileID", "dbo.ManufacturerWindowProfiles", "ManufacturerWindowProfileID", cascadeDelete: true);
            DropColumn("dbo.WindowProfiles", "MarkProfileID");
            DropTable("dbo.MarkProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MarkProfiles",
                c => new
                    {
                        MarkProfileID = c.Int(nullable: false, identity: true),
                        ManufacturerWindowProfileID = c.Int(nullable: false),
                        TitleMark = c.String(),
                    })
                .PrimaryKey(t => t.MarkProfileID);
            
            AddColumn("dbo.WindowProfiles", "MarkProfileID", c => c.Int(nullable: false));
            DropForeignKey("dbo.WindowProfiles", "ManufacturerWindowProfileID", "dbo.ManufacturerWindowProfiles");
            DropIndex("dbo.WindowProfiles", new[] { "ManufacturerWindowProfileID" });
            DropColumn("dbo.WindowProfiles", "TitleMark");
            DropColumn("dbo.WindowProfiles", "ManufacturerWindowProfileID");
            CreateIndex("dbo.WindowProfiles", "MarkProfileID");
            CreateIndex("dbo.MarkProfiles", "ManufacturerWindowProfileID");
            AddForeignKey("dbo.WindowProfiles", "MarkProfileID", "dbo.MarkProfiles", "MarkProfileID", cascadeDelete: true);
            AddForeignKey("dbo.MarkProfiles", "ManufacturerWindowProfileID", "dbo.ManufacturerWindowProfiles", "ManufacturerWindowProfileID", cascadeDelete: true);
        }
    }
}
