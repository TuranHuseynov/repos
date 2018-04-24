using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    [AdminFilterController]
    public class NavbarController : Controller
    {
        private TravelEntities db = new TravelEntities();

        // GET: Navbar
        public ActionResult Index()
        {
            return View(db.Navbars.ToList());
        }

        // GET: Navbar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navbar navbar = db.Navbars.Find(id);
            if (navbar == null)
            {
                return HttpNotFound();
            }
            return View(navbar);
        }

        // GET: Navbar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Navbar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nav_id,nav_name,nav_url")] Navbar navbar)
        {
            if (ModelState.IsValid)
            {
                db.Navbars.Add(navbar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(navbar);
        }

        // GET: Navbar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navbar navbar = db.Navbars.Find(id);
            if (navbar == null)
            {
                return HttpNotFound();
            }
            return View(navbar);
        }

        // POST: Navbar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nav_id,nav_name,nav_url")] Navbar navbar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(navbar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(navbar);
        }

        // GET: Navbar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navbar navbar = db.Navbars.Find(id);
            if (navbar == null)
            {
                return HttpNotFound();
            }
            return View(navbar);
        }

        // POST: Navbar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Navbar navbar = db.Navbars.Find(id);
            db.Navbars.Remove(navbar);
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
