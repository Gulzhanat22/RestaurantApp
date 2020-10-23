using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace RestaurantApp.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private string strCart = "Cart";
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session[strCart] == null)
            {
                List<Cart> lsCart = new List<Cart>
                {
                    new Cart(db.Menus.Find(id), 1)
                };
                Session[strCart] = lsCart;
            }
            else
            {
                List<Cart> lsCart = (List<Cart>)Session[strCart];
                int check = isExistingCheck(id);
                if (check == -1)
                    lsCart.Add(new Cart(db.Menus.Find(id), 1));
                else
                    lsCart[check].Quantity++;
                Session[strCart] = lsCart;
            }
            return View("Index");
        }
        private int isExistingCheck(int? id)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < lsCart.Count; i++)
            {
                if (lsCart[i].Menu.Id == id) return i;
            }
            return -1;
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int check = isExistingCheck(id);
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            lsCart.RemoveAt(check);
            return View("Index");
        }
        public ActionResult UpdateCart(FormCollection frc)
        {
            string[] quantities = frc.GetValues("quantity");
            List<Cart> lstCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < lstCart.Count; i++)
            {
                lstCart[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session[strCart] = lstCart;
            return View("Index");
        }
        public ActionResult CheckOut()
        {

            return View("CheckOut");
        }
        public ActionResult ProcessOrder(FormCollection frc)
        {

            List<Cart> lstCart = (List<Cart>)Session[strCart];
            Order order = new Order()
            {
                Name = frc["Name"],
                UserId = User.Identity.GetUserId(),
                OrderTime = DateTimeOffset.UtcNow,
                PaymentType = "Cash"
            };
            db.Orders.Add(order);
            db.SaveChanges();
            foreach (Cart cart in lstCart)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderId = order.Id,
                    MenuId = cart.Menu.Id,
                    Quantity = cart.Quantity,
                    Price = cart.Menu.Price,
                    RestaurantId = cart.Menu.RestaurantId,
                    Status= null
                };
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }
            Session.Remove(strCart);
            return View("OrderSuccess");
        }
    }
}