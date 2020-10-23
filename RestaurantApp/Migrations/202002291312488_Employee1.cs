namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employees", new[] { "Role_Id" });
            DropColumn("dbo.Employees", "RoleId");
            RenameColumn(table: "dbo.Employees", name: "Role_Id", newName: "RoleId");
            AlterColumn("dbo.Employees", "RoleId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "RoleId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "RoleId" });
            AlterColumn("dbo.Employees", "RoleId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Employees", name: "RoleId", newName: "Role_Id");
            AddColumn("dbo.Employees", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "Role_Id");
        }
    }
}
