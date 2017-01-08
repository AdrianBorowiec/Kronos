namespace Kronos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Decimale : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DebtItems", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Debts", "TotalAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Debts", "TotalAmount", c => c.Double());
            AlterColumn("dbo.DebtItems", "Value", c => c.Double(nullable: false));
        }
    }
}
