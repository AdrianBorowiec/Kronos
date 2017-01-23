namespace Kronos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieUtargu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Earnings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ByCart = c.Decimal(nullable: false, precision: 2, scale: 2),
                        ByCash = c.Decimal(nullable: false, precision: 2, scale: 2),
                        Sum = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Earnings");
        }
    }
}
