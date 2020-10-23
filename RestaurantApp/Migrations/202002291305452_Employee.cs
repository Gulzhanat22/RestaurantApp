namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpolyeeId = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        WorkerId = c.String(maxLength: 128),
                        RoleId = c.Int(nullable: false),
                        Role_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmpolyeeId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.Role_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.WorkerId)
                .Index(t => t.RestaurantId)
                .Index(t => t.WorkerId)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "WorkerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "Role_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.Employees", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Employees", new[] { "Role_Id" });
            DropIndex("dbo.Employees", new[] { "WorkerId" });
            DropIndex("dbo.Employees", new[] { "RestaurantId" });
            DropTable("dbo.Employees");
        }
    }
}
