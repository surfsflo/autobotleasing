using ABLeasing.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Accounts
{
    public class Client : UserProfile
    {
        public float DepositAmount { get; set; }
        public float PeriodicDepositAmount { get; set; }
        public string Frequency { get; set; }
        public bool AutoPay { get; set; }
    }
}