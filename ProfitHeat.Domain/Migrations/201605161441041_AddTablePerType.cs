namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablePerType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wall",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID)
                .ForeignKey("dbo.Claddings", t => t.CladdingID)
                .Index(t => t.CladdingID);
            
            CreateTable(
                "dbo.Ceiling",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID)
                .ForeignKey("dbo.Claddings", t => t.CladdingID)
                .Index(t => t.CladdingID);
            
            CreateTable(
                "dbo.Floor",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID)
                .ForeignKey("dbo.Claddings", t => t.CladdingID)
                .Index(t => t.CladdingID);
            
            CreateTable(
                "dbo.Door",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID)
                .ForeignKey("dbo.Claddings", t => t.CladdingID)
                .Index(t => t.CladdingID);
            
            DropColumn("dbo.Claddings", "CladdingType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Claddings", "CladdingType", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Door", "CladdingID", "dbo.Claddings");
            DropForeignKey("dbo.Floor", "CladdingID", "dbo.Claddings");
            DropForeignKey("dbo.Ceiling", "CladdingID", "dbo.Claddings");
            DropForeignKey("dbo.Wall", "CladdingID", "dbo.Claddings");
            DropIndex("dbo.Door", new[] { "CladdingID" });
            DropIndex("dbo.Floor", new[] { "CladdingID" });
            DropIndex("dbo.Ceiling", new[] { "CladdingID" });
            DropIndex("dbo.Wall", new[] { "CladdingID" });
            DropTable("dbo.Door");
            DropTable("dbo.Floor");
            DropTable("dbo.Ceiling");
            DropTable("dbo.Wall");
        }
    }
}
