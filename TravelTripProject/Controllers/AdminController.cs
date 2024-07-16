﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var values = c.Blogs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBlog(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var value = c.Blogs.Find(id);
            return View("UpdateBlog", value);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            var value = c.Blogs.Find(p.Id);
            value.Title = p.Title;
            value.Date = p.Date;
            value.Explanation = p.Explanation;
            value.BlogImage = p.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAllComments()
        {
            var values = c.Comments.ToList();
            return View(values);
        }

        public ActionResult DeleteComment(int id)
        {
            var comment = c.Comments.Find(id);
            c.Comments.Remove(comment);
            c.SaveChanges();
            return RedirectToAction("GetAllComments");
        }


        [HttpGet]
        public ActionResult UpdateComment(int id)
        {
            var value = c.Comments.Find(id);
            return View("UpdateComment", value);
        }

        [HttpPost]
        public ActionResult UpdateComment(Comment p)
        {
            var value = c.Comments.Find(p.Id);
            value.UserName = p.UserName;
            value.Mail = p.Mail;
            value.CommentText = p.CommentText;
            c.SaveChanges();
            return RedirectToAction("GetAllComments");
        }
    }
}