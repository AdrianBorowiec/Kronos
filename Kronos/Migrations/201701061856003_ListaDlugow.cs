namespace Kronos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListaDlugow : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employee", newName: "Employees");
            RenameTable(name: "dbo.RequisitionItem", newName: "RequisitionItems");
            CreateTable(
                "dbo.DebtItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Value = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        DebtId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Debts", t => t.DebtId, cascadeDelete: true)
                .Index(t => t.DebtId);
            
            CreateTable(
                "dbo.Debts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Debtor = c.String(nullable: false),
                        TotalAmount = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.RequisitionItems", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.RequisitionItems", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RequisitionItems", "RequisitionType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DebtItems", "DebtId", "dbo.Debts");
            DropIndex("dbo.DebtItems", new[] { "DebtId" });
            AlterColumn("dbo.RequisitionItems", "RequisitionType", c => c.Int());
            AlterColumn("dbo.RequisitionItems", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.RequisitionItems", "Name", c => c.String());
            AlterColumn("dbo.Employees", "Password", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            DropTable("dbo.Debts");
            DropTable("dbo.DebtItems");
            RenameTable(name: "dbo.RequisitionItems", newName: "RequisitionItem");
            RenameTable(name: "dbo.Employees", newName: "Employee");
        }
    }
}
