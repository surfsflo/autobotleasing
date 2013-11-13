using ABLeasing.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Transactions
{
    public class ClientTransaction : Transaction
    {
        public int ClientId { get; set; }
        public CTType Type { get; set; }
        public virtual Client Client { get; set; }
    }

    public enum CTType
    {
        ScheduledDeposit,
        UnscheduledDeposit,
        MembershipFeePayment,
        PurchaseCooperativeTransfer,
        Refund,
        PurchaseCooperativeDeposit
    }


}