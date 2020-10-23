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
    public class UserRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserRoles
        public ActionResult Index(int? restaurantId = null)
        {
            var userRoles = db.UserRoles.Include(u => u.Restaurant).Where(x => x.RestaurantId == restaurantId).Include(u => u.Role).Include(u => u.User);
            return View(userRoles.ToList());
        }

        // GET: UserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name");
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: UserRoles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,RoleId,RestaurantId")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.UserRoles.Add(userRole);
                db.SaveChanges();
                return RedirectToAction("Success", "Home");
            }

            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", userRole.RestaurantId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", userRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", userRole.UserId);
            return View(userRole);
        }

        // GET: UserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", userRole.RestaurantId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", userRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", userRole.UserId);
            return View(userRole);
        }

        // POST: UserRoles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,RoleId,RestaurantId")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Success", "Home");
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "Id", "Name", userRole.RestaurantId);
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name", userRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", userRole.UserId);
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRole userRole = db.UserRoles.Find(id);
            db.UserRoles.Remove(userRole);
            db.SaveChanges();
            return RedirectToAction("Success", "Home");
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
