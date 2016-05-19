namespace ProfitHeat.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablePipes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pipes",
                c => new
                    {
                        PipeID = c.Int(nullable: false, identity: true),
                        Diametr = c.Int(nullable: false),
                        BoilerPower = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PipeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pipes");
        }
    }
}
