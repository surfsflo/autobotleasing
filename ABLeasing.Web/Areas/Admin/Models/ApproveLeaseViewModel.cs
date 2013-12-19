using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABLeasing.Web.Models;

namespace ABLeasing.Web.Areas.Admin.Models
{
    public class ApproveLeaseViewModel
    {
        public int Id { get; set; }
        public string LeaseName { get; set; }
        public string OpName { get; set; }
        public Comment Comment { get; set; }
    }
}