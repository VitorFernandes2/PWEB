namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeStateFromReservation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reservations", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "State", c => c.Boolean(nullable: false));
        }
    }
}
