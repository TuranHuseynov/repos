using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    [AdminFilterController]
    public class GalleryController : Controller
    {
        private TravelEntities db = new TravelEntities();

        // GET: Gallery
        public ActionResult Index()
        {
            var galleries = db.Galleries.Include(g => g.User);
            return View(galleries.ToList());
        }

        // GET: Gallery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // GET: Gallery/Create
        public ActionResult Create()
        {
            ViewBag.galery_user_id = new SelectList(db.Users, "user_id", "user_full_name");
            return View();
        }

        // POST: Gallery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "galery_id,galery_user_id,galery_comment")] Gallery gallery, HttpPostedFileBase img_src)
        {
            if (ModelState.IsValid)
            {
                if (Path.GetExtension(img_src.FileName) == ".jpg" || Path.GetExtension(img_src.FileName) == ".jpeg")
                {
                    var file_name = Path.GetFileName(img_src.FileName);
                    var src = Path.Combine(Server.MapPath("/Upload"), file_name);
                    img_src.SaveAs(src);
                }
                gallery.img_src = Path.GetFileName(img_src.FileName);
                db.Galleries.Add(gallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.galery_user_id = new SelectList(db.Users, "user_id", "user_full_name", gallery.galery_user_id);
            return View(gallery);
        }

        // GET: Gallery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            ViewBag.galery_user_id = new SelectList(db.Users, "user_id", "user_full_name", gallery.galery_user_id);
            return View(gallery);
        }

        // POST: Gallery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "galery_id,galery_user_id,img_src,galery_comment")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.galery_user_id = new SelectList(db.Users, "user_id", "user_full_name", gallery.galery_user_id);
            return View(gallery);
        }

        // GET: Gallery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Gallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = db.Galleries.Find(id);
            db.Galleries.Remove(gallery);
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
