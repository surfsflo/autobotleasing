using ABLeasing.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class PurchaseCooperative : BaseModelWithComment
    {

        [Key]
        [ForeignKey("Lease")]
        public int PurchaseCooperativeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal AmountFinanced { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public Lease Lease { get; set; }
    }
}