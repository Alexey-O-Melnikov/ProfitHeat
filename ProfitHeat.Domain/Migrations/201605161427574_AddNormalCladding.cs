namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNormalCladding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Claddings", "CladdingType", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Claddings", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Claddings", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Claddings", "CladdingType");
        }
    }
}
