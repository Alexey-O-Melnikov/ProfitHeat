namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColNumLayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WallLayers", "NumLayer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WallLayers", "NumLayer");
        }
    }
}
