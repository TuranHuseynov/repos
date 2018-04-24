using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;
using Travel.ViewModel;

namespace Travel.Controllers
{

    public class ProfileController : Controller
    {
        TravelEntities db = new TravelEntities();
        MyModel vm = new MyModel();
        // GET: Profile
        public ActionResult Index()
        {
            int a = Convert.ToInt32(Session["id"]);
            vm._user = db.Users.Where(u => u.user_id == a).ToList();
            vm._travell = db.Tras.Where(t => t.travel_user_id == a).ToList();
            vm._navbar = db.Navbars.ToList();
            vm._contact = db.Contacts.ToList();
            vm._join = db.Joins.Where(m => m.join_user_id == a).Take(1).ToList();
            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit()
        {

            int a = Convert.ToInt32(Session["id"]);
            vm._contact = db.Contacts.ToList();
            vm._user = db.Users.Where(u => u.user_id == a).ToList();
            return View(vm);
        }


        [HttpPost]
        public ActionResult Edit(FormCollection frm)
        {
            vm._contact = db.Contacts.ToList();
            
            int a = Convert.ToInt32(Session["id"]);
            vm._user = db.Users.Where(u => u.user_id == a).ToList();
            User usr = new User();
            usr.user_img = frm["user_img"];
            usr.user_full_name = frm["user_full_name"];
            usr.user_email = frm["user_email"];
            usr.user_phone = frm["user_phone"];
            usr.user_city = frm["user_city"];
            usr.user_car_model = frm["user_car_model"];
            usr.user_car_marka = frm["user_car_marka"];
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {

            vm._navbar = db.Navbars.ToList();
            vm._contact = db.Contacts.ToList();
            int a = Convert.ToInt32(Session["id"]);
            if (a > 0)
            {
                Tra tras = db.Tras.Find(Id);
                db.Tras.Remove(tras);
                db.SaveChanges();
     
            }
            return RedirectToAction("Index");

        }

        public ActionResult Page(int? id)
        {
            if(Session["id"] != null)
            {
                vm._join = db.Joins.Where(j => j.User.user_id == id).ToList();
                vm._post = db.Postts.ToList();
                vm._user = db.Users.ToList();
                vm._navbar = db.Navbars.ToList();
                vm._contact = db.Contacts.ToList();
                return View(vm);

            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }


       
    }
    
  


}