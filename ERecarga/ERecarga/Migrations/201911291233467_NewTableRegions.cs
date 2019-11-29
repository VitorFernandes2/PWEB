namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableRegions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RegionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Regions");
        }
    }
}
