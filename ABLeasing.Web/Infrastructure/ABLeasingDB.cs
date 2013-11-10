using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ABLeasing.Web.Models;

namespace ABLeasing.Web.Infrastructure
{
    public class ABLeasingDB : DbContext
    {

        public ABLeasingDB(string connection) : base("DefaultConnection") 
        {
        }   
        
        public DbSet<Client> clients {get; set;}

    }
}