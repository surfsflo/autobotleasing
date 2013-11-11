using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public int Rating { get; set; }
        public int ResearcherId { get; set; }
        public string GPSLocation { get; set; }
        public string CellProvider { get; set; }
        public string CellServiceType { get; set; }
        public int ContactId { get; set; }
        public string Type { get; set; }
        public int productRating { get; set; }



       // public virtual Contact Contact { get; set; }
    }
}