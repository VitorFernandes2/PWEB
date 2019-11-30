namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StationUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stations", "OwnerId", c => c.String());
            DropColumn("dbo.Stations", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stations", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Stations", "OwnerId");
        }
    }
}
