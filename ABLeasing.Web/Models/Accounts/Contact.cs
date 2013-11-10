using DataAnnotationsExtensions;
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
        public string PhoneNumber { get; set; }
        public string Alias { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Country { get; set; }
        public string Postal { get; set; }
        [Email]
        public string Email { get; set; }

    }
}