namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regionchange2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Regions", "Name", c => c.String(nullable: false, maxLength: 126));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Regions", "Name", c => c.String(nullable: false));
        }
    }
}
