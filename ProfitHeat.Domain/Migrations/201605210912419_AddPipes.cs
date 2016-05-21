namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPipes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Layers", "PlotID", "dbo.Plots");
            DropForeignKey("dbo.Projects", "PlotID", "dbo.Plots");
            DropIndex("dbo.Layers", new[] { "PlotID" });
            DropIndex("dbo.Projects", new[] { "PlotID" });
            CreateTable(
                "dbo.Pipes",
                c => new
                    {
                        PipeID = c.Int(nullable: false, identity: true),
                        Diametr = c.Int(nullable: false),
                        BoilerPower = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PipeID);
            
            AddColumn("dbo.Layers", "ProjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.Layers", "ProjectID");
            AddForeignKey("dbo.Layers", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            DropColumn("dbo.Layers", "PlotID");
            DropColumn("dbo.Projects", "PlotID");
            DropTable("dbo.Plots");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Plots",
                c => new
                    {
                        PlotID = c.Int(nullable: false, identity: true),
                        WindRose = c.String(),
                        North = c.String(),
                    })
                .PrimaryKey(t => t.PlotID);
            
            AddColumn("dbo.Projects", "PlotID", c => c.Int(nullable: false));
            AddColumn("dbo.Layers", "PlotID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Layers", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Layers", new[] { "ProjectID" });
            DropColumn("dbo.Layers", "ProjectID");
            DropTable("dbo.Pipes");
            CreateIndex("dbo.Projects", "PlotID");
            CreateIndex("dbo.Layers", "PlotID");
            AddForeignKey("dbo.Projects", "PlotID", "dbo.Plots", "PlotID", cascadeDelete: true);
            AddForeignKey("dbo.Layers", "PlotID", "dbo.Plots", "PlotID", cascadeDelete: true);
        }
    }
}
