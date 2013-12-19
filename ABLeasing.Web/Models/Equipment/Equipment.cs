using ABLeasing.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Equipment : BaseModelWithComment
    {

        public int LeaseId { get; set; }
        public virtual Lease Lease { get; set; }

        [Display(Name = "Item Name")]
        [Required]
        public string Name { get; set; }

        public int? Rating { get; set; }

        [UIHint("Enum")]
        public AttachedMonitorState MonitorAttached { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        public string PartNumber { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public decimal RetailPrice { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? PurchasePrice { get; set; }

        public string MaterialType { get; set; }

        public int? ServiceContactId { get; set; }
        public Contact ServiceContact { get; set; }

        public int? SupplierContactId { get; set; }
        public Contact SupplierContact { get; set; }

        [Display(Name = "Cateogory")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }
    }

    public enum AttachedMonitorState
    {
        Approved,
        Unapproved,
        Installed,
        Offline,
        None
    }
}