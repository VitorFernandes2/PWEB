namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newFKtoStation2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stations", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Stations", new[] { "OwnerId" });
            AlterColumn("dbo.Stations", "OwnerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Stations", "OwnerId");
            AddForeignKey("dbo.Stations", "OwnerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stations", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Stations", new[] { "OwnerId" });
            AlterColumn("dbo.Stations", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Stations", "OwnerId");
            AddForeignKey("dbo.Stations", "OwnerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
