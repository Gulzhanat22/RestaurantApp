namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Last1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderDetails", "TimeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "TimeId", c => c.DateTime(nullable: false));
        }
    }
}
