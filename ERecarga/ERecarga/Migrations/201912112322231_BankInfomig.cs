namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BankInfomig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NIB = c.String(),
                        Quant = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankInfoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.BankInfoes", new[] { "UserId" });
            DropTable("dbo.BankInfoes");
        }
    }
}
