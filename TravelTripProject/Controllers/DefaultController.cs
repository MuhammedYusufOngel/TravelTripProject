using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Blogs.ToList();
            return View(values);
        }

        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult PartialTop()
        {
            var values = c.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTop10()
        {
            var values = c.Blogs.OrderByDescending(x => x.Id).Take(10).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialRecentBlogs()
        {
            var values = c.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialFirstBlogs()
        {
            var values = c.Blogs.Take(3).ToList();
            return PartialView(values);
        }
    }
}