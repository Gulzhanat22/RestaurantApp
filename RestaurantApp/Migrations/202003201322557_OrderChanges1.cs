namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderChanges1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetailOrders", "OrderDetail_Id", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetailOrders", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderDetailOrders", new[] { "OrderDetail_Id" });
            DropIndex("dbo.OrderDetailOrders", new[] { "Order_Id" });
            CreateIndex("dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            DropTable("dbo.OrderDetailOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderDetailOrders",
                c => new
                    {
                        OrderDetail_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderDetail_Id, t.Order_Id });
            
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            CreateIndex("dbo.OrderDetailOrders", "Order_Id");
            CreateIndex("dbo.OrderDetailOrders", "OrderDetail_Id");
            AddForeignKey("dbo.OrderDetailOrders", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetailOrders", "OrderDetail_Id", "dbo.OrderDetails", "Id", cascadeDelete: true);
        }
    }
}
