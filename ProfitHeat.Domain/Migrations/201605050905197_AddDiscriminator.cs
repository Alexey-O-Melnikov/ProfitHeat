namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiscriminator : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Claddings", name: "Discriminator", newName: "Discriminator");
            AlterColumn("dbo.Claddings", "Discriminator", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Claddings", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.Claddings", name: "Discriminator", newName: "Discriminator");
        }
    }
}
