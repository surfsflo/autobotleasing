using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Comments
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        //public virtual Contact Contact { get; set; }
        //public virtual UserProfile UserProfile { get; set; }
    }
}