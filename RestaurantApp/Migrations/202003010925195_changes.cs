namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Employees", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Employees", "WorkerId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "RestaurantId" });
            DropIndex("dbo.Employees", new[] { "WorkerId" });
            DropIndex("dbo.Employees", new[] { "RoleId" });
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpolyeeId = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        WorkerId = c.String(maxLength: 128),
                        RoleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmpolyeeId);
            
            CreateIndex("dbo.Employees", "RoleId");
            CreateIndex("dbo.Employees", "WorkerId");
            CreateIndex("dbo.Employees", "RestaurantId");
            AddForeignKey("dbo.Employees", "WorkerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.Employees", "RestaurantId", "dbo.Restaurants", "Id", cascadeDelete: true);
        }
    }
}
