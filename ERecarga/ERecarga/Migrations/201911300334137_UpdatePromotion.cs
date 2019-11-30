namespace ERecarga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePromotion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotions", "PromotionStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Promotions", "PromotionEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promotions", "PromotionEnd");
            DropColumn("dbo.Promotions", "PromotionStart");
        }
    }
}
