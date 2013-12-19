using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace ABLeasing.Web.Models.Transactions
{
    public class Transaction : BaseModel
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public TransactionStatus Status { get; set; }

        private ICollection<Comment> _comments;

        public Transaction()
        {
            _comments = new List<Comment>();
        }

        public ICollection<Comment> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

    }

    public enum TransactionStatus
    {
        Requested,
        Posted,
        Cleared
    }
}