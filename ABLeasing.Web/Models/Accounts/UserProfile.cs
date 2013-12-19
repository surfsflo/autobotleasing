using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Accounts
{

    public class UserProfile : BaseModel
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Email]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Current Status")]
        public bool? Status { get; set; }

        public Contact Contact1 { get; set; }
        public Contact Contact2 { get; set; }

        private ICollection<Comment> _comments;

        public UserProfile()
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