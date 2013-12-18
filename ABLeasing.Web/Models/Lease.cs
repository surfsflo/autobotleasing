using ABLeasing.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Lease : BaseModelWithComment
    {

        [Key]
        [ForeignKey("Equipment")]
        public int LeaseId { get; set; }

        public bool Pending { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? PrincipalAmount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? InterestRate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? ProfitShareRate { get; set; }

        [Required]
        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        [ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public virtual Operator Operator { get; set; }

        public int? PurchaseCooperativeId { get; set; }
        public virtual PurchaseCooperative PurchaseCooperative { get; set; }

        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }


    }
}