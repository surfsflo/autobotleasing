using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public abstract class BaseModelWithComment : BaseModel
    {
        public virtual ICollection<Comment> Comments { get; set; }
    }
}