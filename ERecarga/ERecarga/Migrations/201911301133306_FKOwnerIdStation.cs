namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKOwnerIdStation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stations", "Owner_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Stations", "Owner_Id");
            AddForeignKey("dbo.Stations", "Owner_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Stations", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stations", "OwnerId", c => c.String());
            DropForeignKey("dbo.Stations", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Stations", new[] { "Owner_Id" });
            DropColumn("dbo.Stations", "Owner_Id");
        }
    }
}
