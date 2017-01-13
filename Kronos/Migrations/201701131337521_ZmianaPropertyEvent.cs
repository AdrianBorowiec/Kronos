namespace Kronos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianaPropertyEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Events", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Events", "Title");
        }
    }
}
