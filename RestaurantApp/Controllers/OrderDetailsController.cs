using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    [Authorize(Roles = ("Официант"))]
    public class OrderDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderDetails
        public ActionResult Index(int? restaurantId = null)
        {
            
            var orderDetails = db.OrderDetails.Include(o => o.Menu).Include(o => o.Order).OrderByDescending(o=>o.Order.OrderTime).Where(x => x.RestaurantId == restaurantId);
            

            return View(orderDetails.ToList());
        }

        public ActionResult UpdateStatus(int orderId, string status)
        {
            var orderDetail = db.OrderDetails.Where(x => x.Id == orderId).FirstOrDefault();
            orderDetail.Status = status;
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
            
            
            return View();
        }

        // GET: OrderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name");
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Name");
            ViewBag.TimeId = new SelectList(db.Orders, "Id", "OrderTime");
            return View();
        }

        // POST: OrderDetails/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderId,MenuId,RestaurantId,Price,Quantity")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", orderDetail.MenuId);
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Name", orderDetail.OrderId);
            ViewBag.TimeId = new SelectList(db.Orders, "Id", "OrderTime", orderDetail.OrderId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", orderDetail.MenuId);
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Name", orderDetail.OrderId);
            ViewBag.TimeId = new SelectList(db.Orders, "Id", "OrderTime", orderDetail.OrderId);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderId,MenuId,RestaurantId,Price,Quantity")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuId = new SelectList(db.Menus, "Id", "Name", orderDetail.MenuId);
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Name", orderDetail.OrderId);
            ViewBag.TimeId = new SelectList(db.Orders, "Id", "OrderTime", orderDetail.OrderId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            db.OrderDetails.Remove(orderDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
