using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Lease
    {
        public int LeaseId { get; set; }
        public string Name { get; set; }
        public Equipment Equipment { get; set; }
        public int CoopId { get; set; }
        public int OperatorId { get; set; }
        public int EquipmentId{ get; set; }
        public int LocationId{ get; set; }
        public float PrincipalAmount{ get; set; }
        public float interestRate{ get; set; }
        public float ProfitShareRate{ get; set; }

        //public virtual Location Location { get; set; }



    }
}