namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillStationTimeBreak : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FillStationTimeBreaks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FillStation_Id = c.Int(),
                        TimeBreak_TimeBreakId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FillStations", t => t.FillStation_Id)
                .ForeignKey("dbo.TimeBreaks", t => t.TimeBreak_TimeBreakId)
                .Index(t => t.FillStation_Id)
                .Index(t => t.TimeBreak_TimeBreakId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FillStationTimeBreaks", "TimeBreak_TimeBreakId", "dbo.TimeBreaks");
            DropForeignKey("dbo.FillStationTimeBreaks", "FillStation_Id", "dbo.FillStations");
            DropIndex("dbo.FillStationTimeBreaks", new[] { "TimeBreak_TimeBreakId" });
            DropIndex("dbo.FillStationTimeBreaks", new[] { "FillStation_Id" });
            DropTable("dbo.FillStationTimeBreaks");
        }
    }
}
