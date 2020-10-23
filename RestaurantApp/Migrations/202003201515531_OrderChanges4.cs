namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderChanges4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "RestaurantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "RestaurantId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Status", c => c.String());
        }
    }
}
