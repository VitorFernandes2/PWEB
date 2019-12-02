namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFkOfFillStation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FillStations", "Station_Id", "dbo.Stations");
            DropIndex("dbo.FillStations", new[] { "Station_Id" });
            RenameColumn(table: "dbo.FillStations", name: "Station_Id", newName: "StationId");
            AlterColumn("dbo.FillStations", "StationId", c => c.Int(nullable: false));
            CreateIndex("dbo.FillStations", "StationId");
            AddForeignKey("dbo.FillStations", "StationId", "dbo.Stations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FillStations", "StationId", "dbo.Stations");
            DropIndex("dbo.FillStations", new[] { "StationId" });
            AlterColumn("dbo.FillStations", "StationId", c => c.Int());
            RenameColumn(table: "dbo.FillStations", name: "StationId", newName: "Station_Id");
            CreateIndex("dbo.FillStations", "Station_Id");
            AddForeignKey("dbo.FillStations", "Station_Id", "dbo.Stations", "Id");
        }
    }
}
