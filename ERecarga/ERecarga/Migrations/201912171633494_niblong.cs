namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class niblong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BankInfoes", "NIB", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BankInfoes", "NIB", c => c.Int(nullable: false));
        }
    }
}
