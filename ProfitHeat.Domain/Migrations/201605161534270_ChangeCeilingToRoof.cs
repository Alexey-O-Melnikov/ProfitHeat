namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCeilingToRoof : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ceiling", "CladdingID", "dbo.Claddings");
            DropIndex("dbo.Ceiling", new[] { "CladdingID" });
            CreateTable(
                "dbo.Roof",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID)
                .ForeignKey("dbo.Claddings", t => t.CladdingID)
                .Index(t => t.CladdingID);
            
            DropTable("dbo.Ceiling");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ceiling",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID);
            
            DropForeignKey("dbo.Roof", "CladdingID", "dbo.Claddings");
            DropIndex("dbo.Roof", new[] { "CladdingID" });
            DropTable("dbo.Roof");
            CreateIndex("dbo.Ceiling", "CladdingID");
            AddForeignKey("dbo.Ceiling", "CladdingID", "dbo.Claddings", "CladdingID");
        }
    }
}
