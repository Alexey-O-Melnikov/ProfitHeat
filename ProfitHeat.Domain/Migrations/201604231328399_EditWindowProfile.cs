namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditWindowProfile : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.WindowProfiles", "ManufacturerID", c => c.Int(nullable: false));
            CreateIndex("dbo.WindowProfiles", "ManufacturerID");
            AddForeignKey("dbo.WindowProfiles", "ManufacturerID", "dbo.Manufacturers", "ManufacturerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WindowProfiles", "ManufacturerID", "dbo.Manufacturers");
            DropIndex("dbo.WindowProfiles", new[] { "ManufacturerID" });
            DropColumn("dbo.WindowProfiles", "ManufacturerID");
            DropTable("dbo.Manufacturers");
        }
    }
}
