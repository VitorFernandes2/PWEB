namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePromotionFk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotions", "Station_Id", c => c.Int());
            CreateIndex("dbo.Promotions", "Station_Id");
            AddForeignKey("dbo.Promotions", "Station_Id", "dbo.Stations", "Id");
            DropColumn("dbo.Promotions", "SupplyStationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Promotions", "SupplyStationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Promotions", "Station_Id", "dbo.Stations");
            DropIndex("dbo.Promotions", new[] { "Station_Id" });
            DropColumn("dbo.Promotions", "Station_Id");
        }
    }
}
