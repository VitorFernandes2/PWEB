namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeysToAll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FillStationTimeBreaks", "FillStation_Id", "dbo.FillStations");
            DropForeignKey("dbo.FillStationTimeBreaks", "TimeBreak_TimeBreakId", "dbo.TimeBreaks");
            DropForeignKey("dbo.Promotions", "FillStation_Id", "dbo.FillStations");
            DropForeignKey("dbo.Reservations", "FillStationTimeBreak_Id", "dbo.FillStationTimeBreaks");
            DropIndex("dbo.FillStationTimeBreaks", new[] { "FillStation_Id" });
            DropIndex("dbo.FillStationTimeBreaks", new[] { "TimeBreak_TimeBreakId" });
            DropIndex("dbo.Promotions", new[] { "FillStation_Id" });
            DropIndex("dbo.Reservations", new[] { "FillStationTimeBreak_Id" });
            RenameColumn(table: "dbo.FillStationTimeBreaks", name: "FillStation_Id", newName: "FillStationId");
            RenameColumn(table: "dbo.FillStationTimeBreaks", name: "TimeBreak_TimeBreakId", newName: "TimeBreakId");
            RenameColumn(table: "dbo.Promotions", name: "FillStation_Id", newName: "FillStationId");
            RenameColumn(table: "dbo.Reservations", name: "FillStationTimeBreak_Id", newName: "FillStationTimeBreakId");
            RenameColumn(table: "dbo.Reservations", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Reservations", name: "IX_User_Id", newName: "IX_UserId");
            AlterColumn("dbo.FillStationTimeBreaks", "FillStationId", c => c.Int(nullable: false));
            AlterColumn("dbo.FillStationTimeBreaks", "TimeBreakId", c => c.Int(nullable: false));
            AlterColumn("dbo.Promotions", "FillStationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "FillStationTimeBreakId", c => c.Int(nullable: false));
            CreateIndex("dbo.FillStationTimeBreaks", "FillStationId");
            CreateIndex("dbo.FillStationTimeBreaks", "TimeBreakId");
            CreateIndex("dbo.Promotions", "FillStationId");
            CreateIndex("dbo.Reservations", "FillStationTimeBreakId");
            AddForeignKey("dbo.FillStationTimeBreaks", "FillStationId", "dbo.FillStations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FillStationTimeBreaks", "TimeBreakId", "dbo.TimeBreaks", "TimeBreakId", cascadeDelete: true);
            AddForeignKey("dbo.Promotions", "FillStationId", "dbo.FillStations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "FillStationTimeBreakId", "dbo.FillStationTimeBreaks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "FillStationTimeBreakId", "dbo.FillStationTimeBreaks");
            DropForeignKey("dbo.Promotions", "FillStationId", "dbo.FillStations");
            DropForeignKey("dbo.FillStationTimeBreaks", "TimeBreakId", "dbo.TimeBreaks");
            DropForeignKey("dbo.FillStationTimeBreaks", "FillStationId", "dbo.FillStations");
            DropIndex("dbo.Reservations", new[] { "FillStationTimeBreakId" });
            DropIndex("dbo.Promotions", new[] { "FillStationId" });
            DropIndex("dbo.FillStationTimeBreaks", new[] { "TimeBreakId" });
            DropIndex("dbo.FillStationTimeBreaks", new[] { "FillStationId" });
            AlterColumn("dbo.Reservations", "FillStationTimeBreakId", c => c.Int());
            AlterColumn("dbo.Promotions", "FillStationId", c => c.Int());
            AlterColumn("dbo.FillStationTimeBreaks", "TimeBreakId", c => c.Int());
            AlterColumn("dbo.FillStationTimeBreaks", "FillStationId", c => c.Int());
            RenameIndex(table: "dbo.Reservations", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Reservations", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Reservations", name: "FillStationTimeBreakId", newName: "FillStationTimeBreak_Id");
            RenameColumn(table: "dbo.Promotions", name: "FillStationId", newName: "FillStation_Id");
            RenameColumn(table: "dbo.FillStationTimeBreaks", name: "TimeBreakId", newName: "TimeBreak_TimeBreakId");
            RenameColumn(table: "dbo.FillStationTimeBreaks", name: "FillStationId", newName: "FillStation_Id");
            CreateIndex("dbo.Reservations", "FillStationTimeBreak_Id");
            CreateIndex("dbo.Promotions", "FillStation_Id");
            CreateIndex("dbo.FillStationTimeBreaks", "TimeBreak_TimeBreakId");
            CreateIndex("dbo.FillStationTimeBreaks", "FillStation_Id");
            AddForeignKey("dbo.Reservations", "FillStationTimeBreak_Id", "dbo.FillStationTimeBreaks", "Id");
            AddForeignKey("dbo.Promotions", "FillStation_Id", "dbo.FillStations", "Id");
            AddForeignKey("dbo.FillStationTimeBreaks", "TimeBreak_TimeBreakId", "dbo.TimeBreaks", "TimeBreakId");
            AddForeignKey("dbo.FillStationTimeBreaks", "FillStation_Id", "dbo.FillStations", "Id");
        }
    }
}
