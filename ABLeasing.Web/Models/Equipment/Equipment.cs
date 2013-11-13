using ABLeasing.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Equipment : BaseModelWithComment
    {
        [Key]
        public int EquipmentId { get; set; }

        public string Name { get; set; }
        public int Rating { get; set; }
        public AttachedMonitorState MonitorAttached { get; set; }

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string PartNumber { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal PurchasePrice { get; set; }

        public string MaterialType { get; set; }

        public int? ServiceContactID { get; set; }
        public Contact ServiceContact { get; set; }

        public int? SupplierContactID { get; set; }
        public Contact SupplierContact { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? LeaseId { get; set; }
        public virtual Lease Lease { get; set; }

        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }
    }

    public enum AttachedMonitorState
    {
        Approved,
        Unapproved,
        Installed,
        Offline
    }
}