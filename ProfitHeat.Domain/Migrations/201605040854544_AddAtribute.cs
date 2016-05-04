namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAtribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Materials", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Glasses", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Locations", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.ManufacturerRadiators", "TitleCompany", c => c.String(nullable: false));
            AlterColumn("dbo.ManufacturerWindowProfiles", "TitleCompany", c => c.String(nullable: false));
            AlterColumn("dbo.MaterialRadiators", "TitleMaterialRadiator", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Rooms", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Radiators", "TitleModel", c => c.String(nullable: false));
            AlterColumn("dbo.TypeRooms", "TitleTypeRoom", c => c.String(nullable: false));
            AlterColumn("dbo.WindowProfiles", "TitleMark", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WindowProfiles", "TitleMark", c => c.String());
            AlterColumn("dbo.TypeRooms", "TitleTypeRoom", c => c.String());
            AlterColumn("dbo.Radiators", "TitleModel", c => c.String());
            AlterColumn("dbo.Rooms", "Title", c => c.String());
            AlterColumn("dbo.Projects", "Title", c => c.String());
            AlterColumn("dbo.MaterialRadiators", "TitleMaterialRadiator", c => c.String());
            AlterColumn("dbo.ManufacturerWindowProfiles", "TitleCompany", c => c.String());
            AlterColumn("dbo.ManufacturerRadiators", "TitleCompany", c => c.String());
            AlterColumn("dbo.Locations", "Title", c => c.String());
            AlterColumn("dbo.Glasses", "Type", c => c.String());
            AlterColumn("dbo.Materials", "Title", c => c.String());
        }
    }
}
