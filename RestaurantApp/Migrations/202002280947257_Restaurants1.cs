namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restaurants1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restaurants", "AdminId", "dbo.AspNetUsers");
            DropIndex("dbo.Restaurants", new[] { "AdminId" });
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "AdminId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Restaurants", "AdminId");
            AddForeignKey("dbo.Restaurants", "AdminId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "AdminId", "dbo.AspNetUsers");
            DropIndex("dbo.Restaurants", new[] { "AdminId" });
            AlterColumn("dbo.Restaurants", "AdminId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Restaurants", "Location", c => c.String());
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
            CreateIndex("dbo.Restaurants", "AdminId");
            AddForeignKey("dbo.Restaurants", "AdminId", "dbo.AspNetUsers", "Id");
        }
    }
}
