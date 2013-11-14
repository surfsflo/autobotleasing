using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public abstract class BaseModel
    {
        [DisplayFormat(DataFormatString = "{0:ddd MMM d hh:mm:ss}")]
        public DateTime? Created { get; set; }

        [DisplayFormat(DataFormatString = "{0:ddd MMM d hh:mm:ss}")]
        public DateTime? Updated { get; set; }

    }
}