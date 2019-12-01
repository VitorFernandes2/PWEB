namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StationChangeRequiredOwner : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stations", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Stations", new[] { "Owner_Id" });
            AlterColumn("dbo.Stations", "Owner_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Stations", "Owner_Id");
            AddForeignKey("dbo.Stations", "Owner_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stations", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Stations", new[] { "Owner_Id" });
            AlterColumn("dbo.Stations", "Owner_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Stations", "Owner_Id");
            AddForeignKey("dbo.Stations", "Owner_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
