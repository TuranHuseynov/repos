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
    public class UserController : Controller
    {
        private TravelEntities db = new TravelEntities();

        // GET: User
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Gender);
            return View(users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.user_gender_id = new SelectList(db.Genders, "gender_id", "gender_name");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_full_name,user_email,user_password,user_age,user_gender_id,user_phone,user_city,user_fb_link,user_instagram_link,user_twitter_link,user_car_marka,user_car_model,user_car_place")] User user, HttpPostedFileBase user_img)
        {
            if (ModelState.IsValid)
            {
                if (Path.GetExtension(user_img.FileName) == ".jpg" || Path.GetExtension(user_img.FileName) == ".jpeg")
                {
                    var file_name = Path.GetFileName(user_img.FileName);
                    var src = Path.Combine(Server.MapPath("/Upload"), file_name);
                    user_img.SaveAs(src);
                }
                user.user_img = Path.GetFileName(user_img.FileName);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", user.user_gender_id);
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", user.user_gender_id);
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_full_name,user_img,user_email,user_password,user_age,user_gender_id,user_phone,user_city,user_fb_link,user_instagram_link,user_twitter_link,user_car_marka,user_car_model,user_car_place")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_gender_id = new SelectList(db.Genders, "gender_id", "gender_name", user.user_gender_id);
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
