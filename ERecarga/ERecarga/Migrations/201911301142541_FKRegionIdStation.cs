namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKRegionIdStation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stations", "Region_RegionId", c => c.Int());
            CreateIndex("dbo.Stations", "Region_RegionId");
            AddForeignKey("dbo.Stations", "Region_RegionId", "dbo.Regions", "RegionId");
            DropColumn("dbo.Stations", "RegionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stations", "RegionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Stations", "Region_RegionId", "dbo.Regions");
            DropIndex("dbo.Stations", new[] { "Region_RegionId" });
            DropColumn("dbo.Stations", "Region_RegionId");
        }
    }
}
