namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFillStation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FillStations", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FillStations", "Type");
        }
    }
}
