﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ABLeasing.Web.Models;
using ABLeasing.Web.Models.Accounts;
using System.Data.Entity.ModelConfiguration.Conventions;
using ABLeasing.Web.Models.Transactions;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace ABLeasing.Web.Infrastructure
{
    public class ABLeasingDB : DbContext
    {

        public ABLeasingDB()
            : base("DefaultConnection")
        {
        }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<LeaseTransaction> LeaseTransactions { get; set; }
        public DbSet<ClientTransaction> ClientTransactions { get; set; }
        public DbSet<PurchaseCooperative> PurchaseCooperatives { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;

            //Find all Entities that are Added/Modified that inherit from my EntityBase
            IEnumerable<ObjectStateEntry> objectStateEntries =
                from e in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                where
                    e.IsRelationship == false &&
                    e.Entity != null &&
                    typeof(BaseModel).IsAssignableFrom(e.Entity.GetType())
                select e;

            var currentTime = DateTime.Now;

            foreach (var entry in objectStateEntries)
            {
                var entityBase = entry.Entity as BaseModel;

                if (entry.State == EntityState.Added)
                {
                    entityBase.Created = currentTime;
                }

                entityBase.Updated = currentTime;
            }

            return base.SaveChanges();
        }

    }
}