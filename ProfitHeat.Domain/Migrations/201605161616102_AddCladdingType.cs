namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCladdingType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wall", "CladdingID", "dbo.Claddings");
            DropForeignKey("dbo.Roof", "CladdingID", "dbo.Claddings");
            DropForeignKey("dbo.Floor", "CladdingID", "dbo.Claddings");
            DropForeignKey("dbo.Door", "CladdingID", "dbo.Claddings");
            DropIndex("dbo.Wall", new[] { "CladdingID" });
            DropIndex("dbo.Roof", new[] { "CladdingID" });
            DropIndex("dbo.Floor", new[] { "CladdingID" });
            DropIndex("dbo.Door", new[] { "CladdingID" });
            AddColumn("dbo.Claddings", "CladdingType", c => c.String());
            AddColumn("dbo.Claddings", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Wall");
            DropTable("dbo.Roof");
            DropTable("dbo.Floor");
            DropTable("dbo.Door");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Door",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID);
            
            CreateTable(
                "dbo.Floor",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID);
            
            CreateTable(
                "dbo.Roof",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID);
            
            CreateTable(
                "dbo.Wall",
                c => new
                    {
                        CladdingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CladdingID);
            
            DropColumn("dbo.Claddings", "Discriminator");
            DropColumn("dbo.Claddings", "CladdingType");
            CreateIndex("dbo.Door", "CladdingID");
            CreateIndex("dbo.Floor", "CladdingID");
            CreateIndex("dbo.Roof", "CladdingID");
            CreateIndex("dbo.Wall", "CladdingID");
            AddForeignKey("dbo.Door", "CladdingID", "dbo.Claddings", "CladdingID");
            AddForeignKey("dbo.Floor", "CladdingID", "dbo.Claddings", "CladdingID");
            AddForeignKey("dbo.Roof", "CladdingID", "dbo.Claddings", "CladdingID");
            AddForeignKey("dbo.Wall", "CladdingID", "dbo.Claddings", "CladdingID");
        }
    }
}
