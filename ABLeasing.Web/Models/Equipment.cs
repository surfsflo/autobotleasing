using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string name { get; set; }
        public int ResearcherId { get; set; }
        public int CategoryId{ get; set; }
        public int Rating { get; set; }
        //public int MonitorAttached { get; set; }
        public int ServiceContact { get; set; }
        public int ServiceContactId { get; set; }
        public string Manufacturer{ get; set; }
        public string Model { get; set; }
        public string PartNumber { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int LocationId { get; set; }
        public string MaterialType{ get; set; }




        public virtual Lease Lease { get; set; }
        public virtual Location Location { get; set; }
    }
}