using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Comment : BaseModel
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}