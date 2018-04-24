using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;
using Travel.ViewModel;

namespace Travel.Controllers
{
    [UserFilterController]
    
    public class HomeController : Controller
    {
        TravelEntities db = new TravelEntities();
        MyModel vm = new MyModel();
        // GET: Home
       
        public ActionResult Index()
        {
            vm._blog = db.Blogs.ToList();
            vm._navbar = db.Navbars.ToList();
            vm._menu = db.Menus.ToList();
            vm._user = db.Users.ToList();
            vm._service = db.Services.Take(3).ToList();
            vm._comment = db.Comments.ToList();
            vm._gallery = db.Galleries.Take(6).ToList();
            vm._contact = db.Contacts.ToList();
            return View(vm);
        }

        [UserFilterController]
        public ActionResult AllTravel(string travel_to, string travel_from)
        {
            
            if (travel_from!=null && travel_to !=null)
            {
                vm._navbar = db.Navbars.ToList();
                vm._user = db.Users.ToList();
                vm._travell = (from s in db.Tras
                               orderby s.travel_id descending
                               select s).ToList();
                vm._travell = db.Tras.Where(a=>a.travel_from.Contains(travel_from) && a.travel_to.Contains(travel_to)).ToList();
      
                vm._travel_type = db.Travel_Type.ToList();
                vm._contact = db.Contacts.ToList();
                return View(vm);
            }
            else
            {
                vm._navbar = db.Navbars.ToList();
                vm._user = db.Users.ToList();
                vm._travell = db.Tras.ToList();
                vm._travel_type = db.Travel_Type.ToList();
                vm._contact = db.Contacts.ToList();
                return View(vm);
            }
        }

        public ActionResult ResultSearch(string search)
        {
            vm._user = db.Users.ToList();
            vm._navbar = db.Navbars.ToList();
            vm._contact = db.Contacts.ToList();
            vm._travell = db.Tras.Where(t => t.travel_from.Contains(search) || t.travel_access_point.Contains(search)).ToList();
            vm._travell = (from s in db.Tras
                           orderby s.travel_id descending
                           select s).ToList();
            return PartialView("FilterPartial",vm);

        }
        
        [AllowAnonymous]
        public ActionResult Blog(int id)
        {
                vm._service = db.Services.Where(b => b.service_id == id).ToList();
                vm._blog = db.Blogs.ToList();
                vm._contact = db.Contacts.ToList();
                vm._navbar = db.Navbars.ToList();
                return View(vm);
            
        
            
        } 
        [AllowAnonymous]
        public ActionResult Post(int id)
        {
            vm._gallery = db.Galleries.Where(g => g.galery_id == id).ToList();
            vm._user = db.Users.ToList();
            vm._post = db.Postts.ToList();
            vm._contact = db.Contacts.ToList();
            vm._navbar = db.Navbars.ToList();
              
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult travelPost(int id)
        {
            vm._travell = db.Tras.Where(t => t.travel_id == id).ToList();
            vm._travell = (from s in db.Tras
                           orderby s.travel_id descending
                           select s).ToList();
            vm._user = db.Users.ToList();
            vm._contact = db.Contacts.ToList();
            vm._navbar = db.Navbars.ToList();
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult AddTravel()
        {
            int a = Convert.ToInt32(Session["id"]);
            vm._navbar = db.Navbars.ToList();
            vm._contact = db.Contacts.ToList();

            return View(vm);
        } 
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddTravel(FormCollection frm)
        {
            int a = Convert.ToInt32(Session["id"]);
            vm._navbar = db.Navbars.ToList();
            vm._contact = db.Contacts.ToList();
            Tra travels = new Tra();
            travels.travel_from = frm["from"];
            travels.travel_to = frm["to"];
            travels.travel_user_id = a;
            travels.travel_access_point = frm["accsess"];
            travels.travel_notice = frm["note"];
            travels.travel_price = frm["price"];
            db.Tras.Add(travels);
            db.SaveChanges();


            return View(vm);
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            vm._navbar = db.Navbars.ToList();
            vm._user = db.Users.ToList();
            vm._contact = db.Contacts.ToList();
            vm._gender = db.Genders.ToList();
            return View(vm);
        
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(FormCollection frmregist)
        {
            vm._navbar = db.Navbars.ToList();
            vm._contact = db.Contacts.ToList();

            User newuser = new User();

            newuser.user_full_name = frmregist["fullname"];
            newuser.user_email = frmregist["email"];
            newuser.user_img = frmregist["photo"];
            newuser.user_password = frmregist["password"];
            newuser.user_phone = frmregist["phone"];
            newuser.user_car_model = frmregist["carmodel"];
            newuser.user_car_marka = frmregist["carmarka"];
            db.Users.Add(newuser);
            db.SaveChanges();

            return View(vm);

        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Message()
        {
            vm._navbar = db.Navbars.ToList();
            vm._contact = db.Contacts.ToList();
            return View(vm);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Message(FormCollection frm)
        {
            vm._navbar = db.Navbars.ToList();
            vm._contact = db.Contacts.ToList();

            Message msg = new Message();
            msg.message_email = frm["message_email"];
            msg.message_content = frm["message_content"];
            db.Messages.Add(msg);
            db.SaveChanges();


            return View(vm);
        }

        [HttpPost]
        public ActionResult Join(string joinuser)
        {
            var join = Convert.ToInt32(joinuser);
            var joined = Convert.ToInt32(Session["id"]);
            db.Joins.Add(new Join
            {
                joined_user_id=joined,
                join_user_id=join
            });
            db.SaveChanges();
            vm._navbar = db.Navbars.ToList();
            vm._contact = db.Contacts.ToList();


            return RedirectToAction("AllTravel","Home");
        }


        [HttpGet]
        public ActionResult PhotoGallery()
        {

            vm._navbar = db.Navbars.ToList();
            vm._contact = db.Contacts.ToList();
            return View(vm);

        }
        [HttpPost]
        public ActionResult PhotoGallery(FormCollection frmphoto)
        {
            vm._navbar = db.Navbars.ToList();
            vm._contact = db.Contacts.ToList();
            

            int a = Convert.ToInt32(Session["id"]);
            Gallery photos = new Gallery();
            photos.galery_user_id = a;
            photos.img_src = frmphoto["img_src"];
            photos.galery_comment = frmphoto["galery_comment"];
            db.Galleries.Add(photos);
            db.SaveChanges();
            return View(vm);

        }


















    }
}