namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "State", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "State");
        }
    }
}
