namespace Kronos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieIlosciZakupionychProduktow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DebtItems", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DebtItems", "Quantity");
        }
    }
}
