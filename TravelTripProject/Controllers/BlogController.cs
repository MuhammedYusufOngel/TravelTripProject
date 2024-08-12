using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogComment blogComment = new BlogComment();
        public ActionResult Index()
        {

            //var values = c.Blogs.ToList();

            blogComment.Value1 = c.Blogs.OrderByDescending(x => x.Id).ToList();
            blogComment.Value2 = c.Comments.ToList();
            blogComment.Recent3Blogs = c.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return View(blogComment);
        }

        public ActionResult BlogDetails(int id)
        {
            //var values = c.Blogs.Where(x => x.Id == id).ToList();

            blogComment.Value1 = c.Blogs.Where(x => x.Id == id).ToList();
            blogComment.Value2 = c.Comments.Where(x => x.BlogId == id).ToList();

            var blog = c.Blogs.Where(x => x.Id == id).FirstOrDefaultAsync();

            ViewBag.title1 = blog.Result.Title;
            return View(blogComment);
        }

        [HttpGet]
        public PartialViewResult PartialComment(int id)
        {
            blogComment.Value2 = c.Comments.Where(x => x.BlogId == id).ToList();
            ViewBag.id = id;
            return PartialView(blogComment);
        }

        [HttpPost]
        public PartialViewResult PartialComment(Comment p)
        {
            using (var context = new Context())
            {
                var comment = new Comment
                {
                    UserName = p.UserName,
                    Mail = p.Mail,
                    BlogId = p.BlogId,
                    CommentText = p.CommentText,
                };

                context.Comments.Add(comment);
                context.SaveChanges();

                return PartialView();
            }
        }
    }
}