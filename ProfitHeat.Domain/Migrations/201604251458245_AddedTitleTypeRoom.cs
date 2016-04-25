namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitleTypeRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeRooms", "TitleTypeRoom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeRooms", "TitleTypeRoom");
        }
    }
}
