namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderChanges3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "RestaurantId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "RestaurantId");
        }
    }
}
