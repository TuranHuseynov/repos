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
    public class Travel_TypeController : Controller
    {
        private TravelEntities db = new TravelEntities();

        // GET: Travel_Type
        public ActionResult Index()
        {
            return View(db.Travel_Type.ToList());
        }

        // GET: Travel_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel_Type travel_Type = db.Travel_Type.Find(id);
            if (travel_Type == null)
            {
                return HttpNotFound();
            }
            return View(travel_Type);
        }

        // GET: Travel_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Travel_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "t_type_id,t_ttype_name")] Travel_Type travel_Type)
        {
            if (ModelState.IsValid)
            {
                db.Travel_Type.Add(travel_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(travel_Type);
        }

        // GET: Travel_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel_Type travel_Type = db.Travel_Type.Find(id);
            if (travel_Type == null)
            {
                return HttpNotFound();
            }
            return View(travel_Type);
        }

        // POST: Travel_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "t_type_id,t_ttype_name")] Travel_Type travel_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travel_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(travel_Type);
        }

        // GET: Travel_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel_Type travel_Type = db.Travel_Type.Find(id);
            if (travel_Type == null)
            {
                return HttpNotFound();
            }
            return View(travel_Type);
        }

        // POST: Travel_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Travel_Type travel_Type = db.Travel_Type.Find(id);
            db.Travel_Type.Remove(travel_Type);
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
