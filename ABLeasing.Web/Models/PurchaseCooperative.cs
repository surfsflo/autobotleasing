using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class PurchaseCooperative
    {
        public int ID { get; set; }
        public string name { get; set; }
        public ICollection<Client> clients { get; set; }
        public Lease lease { get; set; }
    }
}