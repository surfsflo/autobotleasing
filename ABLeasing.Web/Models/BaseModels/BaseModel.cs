using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public abstract class BaseModel
    {

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}