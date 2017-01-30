namespace Kronos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoprawkaStolu : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tables", "IsFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tables", "IsFree", c => c.Boolean(nullable: false));
        }
    }
}
