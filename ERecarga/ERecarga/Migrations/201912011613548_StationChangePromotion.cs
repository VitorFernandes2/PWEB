namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StationChangePromotion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stations", "Region_RegionId", "dbo.Regions");
            DropIndex("dbo.Stations", new[] { "Region_RegionId" });
            AlterColumn("dbo.Stations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Stations", "Region_RegionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Stations", "Region_RegionId");
            AddForeignKey("dbo.Stations", "Region_RegionId", "dbo.Regions", "RegionId", cascadeDelete: true);
            DropColumn("dbo.Stations", "DiscountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stations", "DiscountId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Stations", "Region_RegionId", "dbo.Regions");
            DropIndex("dbo.Stations", new[] { "Region_RegionId" });
            AlterColumn("dbo.Stations", "Region_RegionId", c => c.Int());
            AlterColumn("dbo.Stations", "Name", c => c.String());
            CreateIndex("dbo.Stations", "Region_RegionId");
            AddForeignKey("dbo.Stations", "Region_RegionId", "dbo.Regions", "RegionId");
        }
    }
}
