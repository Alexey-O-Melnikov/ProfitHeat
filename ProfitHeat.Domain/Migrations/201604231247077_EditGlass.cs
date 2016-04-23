namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditGlass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Glasses", "CountCamera", c => c.Int(nullable: false));
            AddColumn("dbo.Glasses", "DistanceBetweenGlasses", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Glasses", "DistanceBetweenGlasses");
            DropColumn("dbo.Glasses", "CountCamera");
        }
    }
}
