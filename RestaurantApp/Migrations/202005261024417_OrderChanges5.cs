namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderChanges5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "TimeId", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "TimeId");
        }
    }
}
