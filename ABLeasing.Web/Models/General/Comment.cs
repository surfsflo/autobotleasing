using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Comment : BaseModel
    {
        [Display(Name = "Comment")]
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}