namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMarkProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MarkProfiles",
                c => new
                    {
                        MarkProfileID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.MarkProfileID);
            
            AddColumn("dbo.ManufacturerWindowProfiles", "MarkProfileID", c => c.Int(nullable: false));
            CreateIndex("dbo.ManufacturerWindowProfiles", "MarkProfileID");
            AddForeignKey("dbo.ManufacturerWindowProfiles", "MarkProfileID", "dbo.MarkProfiles", "MarkProfileID", cascadeDelete: true);
            DropColumn("dbo.ManufacturerWindowProfiles", "TitleProfile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ManufacturerWindowProfiles", "TitleProfile", c => c.String());
            DropForeignKey("dbo.ManufacturerWindowProfiles", "MarkProfileID", "dbo.MarkProfiles");
            DropIndex("dbo.ManufacturerWindowProfiles", new[] { "MarkProfileID" });
            DropColumn("dbo.ManufacturerWindowProfiles", "MarkProfileID");
            DropTable("dbo.MarkProfiles");
        }
    }
}
