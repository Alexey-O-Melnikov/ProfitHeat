namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPotolok : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Potolok",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID)
                .ForeignKey("dbo.Claddings", t => t.CladdingID)
                .Index(t => t.CladdingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Potolok", "CladdingID", "dbo.Claddings");
            DropIndex("dbo.Potolok", new[] { "CladdingID" });
            DropTable("dbo.Potolok");
        }
    }
}
