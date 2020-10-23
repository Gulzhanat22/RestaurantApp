namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Status");
        }
    }
}
