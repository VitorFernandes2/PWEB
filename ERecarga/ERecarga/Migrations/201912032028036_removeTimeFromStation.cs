namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTimeFromStation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stations", "WorkhourBegin");
            DropColumn("dbo.Stations", "WorkhourEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stations", "WorkhourEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stations", "WorkhourBegin", c => c.DateTime(nullable: false));
        }
    }
}
