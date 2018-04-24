using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;
using Travel.ViewModel;

namespace Travel.Controllers
{
    
    public class LoginUserController : Controller
    {
        TravelEntities db = new TravelEntities();
        public static User loguser;
        MyModel vm = new MyModel();


        // GET: LoginUser

        public ActionResult Index()
        {
            vm._navbar = db.Navbars.ToList();
            return View(vm);
        }



        [HttpGet]
        public ActionResult UserLog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLog(User usr)
        {
            loguser = db.Users.Where(e => e.user_email == usr.user_email).FirstOrDefault();
            Session["usr_password"] = usr.user_password;

            
            if (loguser !=null)
            {
                if (loguser.user_password == usr.user_password)
                {
                    Session["usr_email"] = loguser.user_email;
                    Session["id"] = loguser.user_id.ToString();
                    Session["logined_img"] = loguser.user_img;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }


        public ActionResult Logout()
        {
            Session["id"] = null;
            return RedirectToAction("Index", "LoginUser");
        }


    }
}