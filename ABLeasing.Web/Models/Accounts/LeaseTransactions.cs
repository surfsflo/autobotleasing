using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Accounts
{
    public class LeaseTransactions
    {
        public int LeaseTXId { get; set; }
        public int   LeaseId { get; set; }
        public float Amount  { get; set; }
        public string Type   { get; set; }
        public DateTime Date   { get; set; }
        public string Status { get; set; }
        //public string comment { get; set; }

        public virtual Lease Lease { get; set; }
    }
}