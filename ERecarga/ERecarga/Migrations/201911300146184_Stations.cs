namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(nullable: false),
                        DiscountId = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        WorkhourBegin = c.DateTime(nullable: false),
                        WorkhourEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stations");
        }
    }
}
