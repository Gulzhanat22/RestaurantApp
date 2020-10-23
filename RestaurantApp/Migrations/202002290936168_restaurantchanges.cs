namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restaurantchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restaurants", "AdminId", "dbo.AspNetUsers");
            DropIndex("dbo.Restaurants", new[] { "AdminId" });
            AlterColumn("dbo.Restaurants", "Image", c => c.String(nullable: false));
            DropColumn("dbo.Restaurants", "AdminId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "AdminId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Restaurants", "Image", c => c.String());
            CreateIndex("dbo.Restaurants", "AdminId");
            AddForeignKey("dbo.Restaurants", "AdminId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
