namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFillStation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FillStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Open = c.Boolean(nullable: false),
                        Station_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stations", t => t.Station_Id)
                .Index(t => t.Station_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FillStations", "Station_Id", "dbo.Stations");
            DropIndex("dbo.FillStations", new[] { "Station_Id" });
            DropTable("dbo.FillStations");
        }
    }
}
