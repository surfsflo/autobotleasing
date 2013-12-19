using ABLeasing.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Location : BaseModel
    {
        public int LocationId { get; set; }
        public int? ResearcherId { get; set; }
        public int? Rating { get; set; }
        public DbGeography GpsLocation { get; set; }
        public string CellProvider { get; set; }
        public string CellServiceType { get; set; }
        public string Type { get; set; }
        public int? ProductRating { get; set; }

        private ICollection<Comment> _comments;

        public Location()
        {
            _comments = new List<Comment>();
        }

        public ICollection<Comment> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }


    }
}