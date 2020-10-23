namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "Description");
        }
    }
}
