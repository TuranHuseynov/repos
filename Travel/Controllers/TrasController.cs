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
    public class TrasController : Controller
    {
        private TravelEntities db = new TravelEntities();

        // GET: Tras
        public ActionResult Index()
        {
            var tras = db.Tras.Include(t => t.User);
            return View(tras.ToList());
        }

        // GET: Tras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tra tra = db.Tras.Find(id);
            if (tra == null)
            {
                return HttpNotFound();
            }
            return View(tra);
        }

        // GET: Tras/Create
        public ActionResult Create()
        {
            ViewBag.travel_user_id = new SelectList(db.Users, "user_id", "user_full_name");
            return View();
        }

        // POST: Tras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "travel_id,travel_type_id,travel_user_id,travel_from,travel_to,travel_access_point,travel_price,travel_notice,travel_date")] Tra tra)
        {
            if (ModelState.IsValid)
            {
                db.Tras.Add(tra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.travel_user_id = new SelectList(db.Users, "user_id", "user_full_name", tra.travel_user_id);
            return View(tra);
        }

        // GET: Tras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tra tra = db.Tras.Find(id);
            if (tra == null)
            {
                return HttpNotFound();
            }
            ViewBag.travel_user_id = new SelectList(db.Users, "user_id", "user_full_name", tra.travel_user_id);
            return View(tra);
        }

        // POST: Tras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "travel_id,travel_type_id,travel_user_id,travel_from,travel_to,travel_access_point,travel_price,travel_notice,travel_date")] Tra tra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.travel_user_id = new SelectList(db.Users, "user_id", "user_full_name", tra.travel_user_id);
            return View(tra);
        }

        // GET: Tras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tra tra = db.Tras.Find(id);
            if (tra == null)
            {
                return HttpNotFound();
            }
            return View(tra);
        }

        // POST: Tras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tra tra = db.Tras.Find(id);
            db.Tras.Remove(tra);
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
