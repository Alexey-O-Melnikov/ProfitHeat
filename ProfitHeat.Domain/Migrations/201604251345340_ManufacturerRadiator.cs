namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManufacturerRadiator : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManufacturerRadiators",
                c => new
                    {
                        ManufacturerRadiatorID = c.Int(nullable: false, identity: true),
                        TitleCompany = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerRadiatorID);
            
            AddColumn("dbo.Radiators", "ManufacturerRadiatorID", c => c.Int(nullable: false));
            AddColumn("dbo.Radiators", "TitleModel", c => c.String());
            AddColumn("dbo.Radiators", "ThermalPower", c => c.Int(nullable: false));
            CreateIndex("dbo.Radiators", "ManufacturerRadiatorID");
            AddForeignKey("dbo.Radiators", "ManufacturerRadiatorID", "dbo.ManufacturerRadiators", "ManufacturerRadiatorID", cascadeDelete: true);
            DropColumn("dbo.Radiators", "RadiatorType");
            DropColumn("dbo.Radiators", "PowerSection");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Radiators", "PowerSection", c => c.Int(nullable: false));
            AddColumn("dbo.Radiators", "RadiatorType", c => c.String());
            DropForeignKey("dbo.Radiators", "ManufacturerRadiatorID", "dbo.ManufacturerRadiators");
            DropIndex("dbo.Radiators", new[] { "ManufacturerRadiatorID" });
            DropColumn("dbo.Radiators", "ThermalPower");
            DropColumn("dbo.Radiators", "TitleModel");
            DropColumn("dbo.Radiators", "ManufacturerRadiatorID");
            DropTable("dbo.ManufacturerRadiators");
        }
    }
}
