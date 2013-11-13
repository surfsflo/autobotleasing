using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Transactions
{
    public class LeaseTransaction : Transaction
    {
        public int LeaseId { get; set; }
        public LTType Type { get; set; }

        public virtual Lease Lease { get; set; }
    }

    public enum LTType
    {
        LeasePayment,
        DisburseToClient
    }

}