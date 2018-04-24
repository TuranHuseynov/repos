using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: LoginAdmin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }



        [HttpPost]
        public ActionResult LogIn(FormCollection frm)
        {
            Session["User_email"] = frm["User_email"];
            Session["User_password"] = frm["User_password"];

            if(Session["User_email"].ToString() == "admin@mail.ru")
            {
                if(Session["User_password"].ToString() == "admin")
                {
                    return RedirectToAction("Index", "Admin");
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


        public ActionResult LogOut()
        {
            Session["User_email"] = null;
            return RedirectToAction("Index","LoginAdmin");
        }
    }
}