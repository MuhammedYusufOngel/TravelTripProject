using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        public string FotoUrl { get; set; }
        public string Explanation { get; set; }
    }
}