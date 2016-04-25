namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMaterialRadiator : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterialRadiators",
                c => new
                    {
                        MaterialRadiatorID = c.Int(nullable: false, identity: true),
                        TitleMaterialRadiator = c.String(),
                    })
                .PrimaryKey(t => t.MaterialRadiatorID);
            
            AddColumn("dbo.Radiators", "MaterialRadiatorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Radiators", "MaterialRadiatorID");
            AddForeignKey("dbo.Radiators", "MaterialRadiatorID", "dbo.MaterialRadiators", "MaterialRadiatorID", cascadeDelete: true);
            DropColumn("dbo.Radiators", "Material");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Radiators", "Material", c => c.String());
            DropForeignKey("dbo.Radiators", "MaterialRadiatorID", "dbo.MaterialRadiators");
            DropIndex("dbo.Radiators", new[] { "MaterialRadiatorID" });
            DropColumn("dbo.Radiators", "MaterialRadiatorID");
            DropTable("dbo.MaterialRadiators");
        }
    }
}
