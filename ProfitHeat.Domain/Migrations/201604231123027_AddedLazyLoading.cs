namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLazyLoading : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TypeRooms", "AirChange", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TypeRooms", "AirChange", c => c.Int(nullable: false));
        }
    }
}
