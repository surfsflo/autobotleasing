using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class ClientTransactions
    {
        public int TransactionId { get; set; }
        public int ClientId { get; set; }
        public float Amount { get; set; }
        public string Type{ get; set; }
        public DateTime Date{ get; set; }
        public string Status { get; set; }
        //public string Comment{ get; set; }

    }
}