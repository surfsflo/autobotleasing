using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Accounts
{
    public class Staff : UserProfile
    {

        [UIHint("Enum")]
        public StaffStatus SStatus { get; set; }
        public StaffRole SRole { get; set; }
        public DateTime? DateHired { get; set; }

    }

    public enum StaffRole
    {
        Admin = 1,
        Clerk,
        Researcher,
        EquipmentResearcher,
        OperatorResearcher,
        LocationResearcher,
        LeaseSignator,
        Cashier
    }

    public enum StaffStatus
    {
        Active = 1,
        Inactive,
        Terminated
    }
}