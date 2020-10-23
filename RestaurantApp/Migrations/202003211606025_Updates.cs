namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
            AlterColumn("dbo.Restaurants", "Location", c => c.String());
            AlterColumn("dbo.Restaurants", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false));
        }
    }
}
