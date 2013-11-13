using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Accounts
{

    public class UserProfile : BaseModelWithComment
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Email]
        public string Email { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }

        public bool? Status { get; set; }
        public Contact Contact1 { get; set; }
        public Contact Contact2 { get; set; }

    }

}