namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTimeBreak : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeBreaks",
                c => new
                    {
                        TimeBreakId = c.Int(nullable: false, identity: true),
                        Begin = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TimeBreakId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TimeBreaks");
        }
    }
}
