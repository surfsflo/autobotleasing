using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Client : UserProfile
    {
        public int ClientId { get; set; }
        public float DepositAmount { get; set; }
        public float PeriodicDepositAmount { get; set; }
        public string Frequency { get; set; }
        public bool AutoPay { get; set; }
    }
}