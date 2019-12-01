namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newFKtoStation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Stations", name: "Region_RegionId", newName: "RegionId");
            RenameColumn(table: "dbo.Stations", name: "Owner_Id", newName: "OwnerId");
            RenameIndex(table: "dbo.Stations", name: "IX_Owner_Id", newName: "IX_OwnerId");
            RenameIndex(table: "dbo.Stations", name: "IX_Region_RegionId", newName: "IX_RegionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Stations", name: "IX_RegionId", newName: "IX_Region_RegionId");
            RenameIndex(table: "dbo.Stations", name: "IX_OwnerId", newName: "IX_Owner_Id");
            RenameColumn(table: "dbo.Stations", name: "OwnerId", newName: "Owner_Id");
            RenameColumn(table: "dbo.Stations", name: "RegionId", newName: "Region_RegionId");
        }
    }
}
