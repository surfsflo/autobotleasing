using System.Web.Script.Serialization;
using ABLeasing.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class PurchaseCooperative : BaseModel
    {

        [Key]
        [ForeignKey("Lease")]
        public int PurchaseCooperativeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal AmountFinanced { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        [ScriptIgnore]
        public Lease Lease { get; set; }

        private ICollection<Comment> _comments;

        public PurchaseCooperative()
        {
            _comments = new List<Comment>();
        }

        public ICollection<Comment> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }


    }
}