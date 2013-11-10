using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Accounts
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }

    }
}