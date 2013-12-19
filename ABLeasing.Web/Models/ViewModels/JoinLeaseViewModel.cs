using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABLeasing.Web.Models.Accounts;

namespace ABLeasing.Web.Models.ViewModels
{
    public class JoinLeaseViewModel
    {
        public Lease Lease { get; set; }
        public Client Client { get; set; }
    }
}