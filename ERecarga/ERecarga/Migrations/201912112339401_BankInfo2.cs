namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BankInfo2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BankInfoes", "NIB", c => c.Int(nullable: false));
            AlterColumn("dbo.BankInfoes", "Quant", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BankInfoes", "Quant", c => c.String());
            AlterColumn("dbo.BankInfoes", "NIB", c => c.String());
        }
    }
}
