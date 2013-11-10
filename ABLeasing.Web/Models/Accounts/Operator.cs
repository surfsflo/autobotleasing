using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Accounts
{
    public class Operator : BaseUser
    {
        public int OperatorId { get; set; }
        public int Rating { get; set; }
        // what is a researcher
        public string TypeOfBuisness { get; set; }
        public string Description { get; set; }

    }
}