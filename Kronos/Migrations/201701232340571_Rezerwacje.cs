namespace Kronos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rezerwacje : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reseravtions", "TableNumber", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reseravtions", "TableNumber");
        }
    }
}
