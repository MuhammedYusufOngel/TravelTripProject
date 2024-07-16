using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class BlogComment
    {
        public IEnumerable<Blog> Value1 { get; set; }
        public IEnumerable<Comment> Value2 { get; set; }
        public IEnumerable<Blog> Recent3Blogs { get; set; }
    }
}