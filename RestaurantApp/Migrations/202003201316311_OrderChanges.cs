namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            CreateTable(
                "dbo.OrderDetailOrders",
                c => new
                    {
                        OrderDetail_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderDetail_Id, t.Order_Id })
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetail_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.OrderDetail_Id)
                .Index(t => t.Order_Id);
            
            AddColumn("dbo.Orders", "OrderDetailsId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetailOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderDetailOrders", "OrderDetail_Id", "dbo.OrderDetails");
            DropIndex("dbo.OrderDetailOrders", new[] { "Order_Id" });
            DropIndex("dbo.OrderDetailOrders", new[] { "OrderDetail_Id" });
            DropColumn("dbo.Orders", "OrderDetailsId");
            DropTable("dbo.OrderDetailOrders");
            CreateIndex("dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
