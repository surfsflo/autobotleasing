using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Accounts
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        [Display(Name = "Public Screen Name")]
        public string Alias { get; set; }

        [Display(Name = "Address Line 1")]
        public string Line1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Line2 { get; set; }

        [Display(Name = "Address Line 3")]
        public string Line3 { get; set; }
        public string Country { get; set; }
        public string Postal { get; set; }
        [Email]
        public string Email { get; set; }

    }
}