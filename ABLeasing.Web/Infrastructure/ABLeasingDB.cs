using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ABLeasing.Web.Models;
using ABLeasing.Web.Models.Accounts;

namespace ABLeasing.Web.Infrastructure
{
    public class ABLeasingDB : DbContext
    {

        public ABLeasingDB() : base("DefaultConnection") 
        {
        }   
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<PurchaseCooperative> PurchaseCooperatives { get; set; }

    }
}