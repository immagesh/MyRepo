using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TableReservation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult LoginPOST()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult SetAuthentication(string PostData1, string PostData2, string PostData3)
        {
            Session["username"] = PostData1;
            Session["email"] = PostData2;
            Session["UserId"] = PostData3;
            FormsAuthentication.SetAuthCookie(PostData1, true);
            return RedirectToAction("Dasboard");
        }

        public ActionResult Dasboard()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}
