namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePromotionFk2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Promotions", "Station_Id", "dbo.Stations");
            DropIndex("dbo.Promotions", new[] { "Station_Id" });
            AddColumn("dbo.Promotions", "FillStation_Id", c => c.Int());
            CreateIndex("dbo.Promotions", "FillStation_Id");
            AddForeignKey("dbo.Promotions", "FillStation_Id", "dbo.FillStations", "Id");
            DropColumn("dbo.Promotions", "Station_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Promotions", "Station_Id", c => c.Int());
            DropForeignKey("dbo.Promotions", "FillStation_Id", "dbo.FillStations");
            DropIndex("dbo.Promotions", new[] { "FillStation_Id" });
            DropColumn("dbo.Promotions", "FillStation_Id");
            CreateIndex("dbo.Promotions", "Station_Id");
            AddForeignKey("dbo.Promotions", "Station_Id", "dbo.Stations", "Id");
        }
    }
}
