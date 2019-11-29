namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegionMappingCreation1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Regions", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Regions", "Name", c => c.String());
        }
    }
}
