using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Accounts
{
    public class Operator : UserProfile
    {
        public int? Rating { get; set; }
        // what is a researcher
        public string TypeOfBusiness { get; set; }
        public string Description { get; set; }

    }
}