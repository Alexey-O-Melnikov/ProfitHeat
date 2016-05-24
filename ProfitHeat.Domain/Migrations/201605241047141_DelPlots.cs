namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelPlots : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "LayerID", "dbo.Layers");
            DropForeignKey("dbo.Layers", "ProjectID", "dbo.Projects");
            DropIndex("dbo.Items", new[] { "LayerID" });
            DropIndex("dbo.Layers", new[] { "ProjectID" });
            DropTable("dbo.Items");
            DropTable("dbo.Layers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Layers",
                c => new
                    {
                        LayerID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        LayerNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LayerID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        LayerID = c.Int(nullable: false),
                        Enclosure = c.String(),
                        StartX = c.Int(nullable: false),
                        StartY = c.Int(nullable: false),
                        EndX = c.Int(nullable: false),
                        EndY = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateIndex("dbo.Layers", "ProjectID");
            CreateIndex("dbo.Items", "LayerID");
            AddForeignKey("dbo.Layers", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.Items", "LayerID", "dbo.Layers", "LayerID", cascadeDelete: true);
        }
    }
}
