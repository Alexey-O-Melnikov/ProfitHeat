namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublicRoof : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Potolok", "CladdingID", "dbo.Claddings");
            DropIndex("dbo.Potolok", new[] { "CladdingID" });
            DropTable("dbo.Potolok");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Potolok",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID);
            
            CreateIndex("dbo.Potolok", "CladdingID");
            AddForeignKey("dbo.Potolok", "CladdingID", "dbo.Claddings", "CladdingID");
        }
    }
}
