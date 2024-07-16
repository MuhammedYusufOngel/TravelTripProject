using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin ad)
        {
            var value = c.Admins.FirstOrDefault(x => x.Username == ad.Username && x.Password == ad.Password);

            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Username, false);
                Session["Username"] = value.Username.ToString();
                return RedirectToAction("Index", "Admin");
            }
                

            else    return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}