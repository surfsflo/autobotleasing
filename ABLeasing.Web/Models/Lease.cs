using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Lease
    {
        public int LeaseId { get; set; }
        public string Name { get; set; }
        public Equipment Equipment { get; set; }
    }
}