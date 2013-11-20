using ABLeasing.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Accounts
{
    public class Client : UserProfile
    {

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? DepositAmount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? PeriodicDepositAmount { get; set; }

        public string Frequency { get; set; }
        public bool? AutoPay { get; set; }
    }
}