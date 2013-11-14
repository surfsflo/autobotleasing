namespace ABLeasing.Web.Migrations
{
    using ABLeasing.Web.Models.Accounts;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<ABLeasing.Web.Infrastructure.ABLeasingDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ABLeasing.Web.Infrastructure.ABLeasingDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );


            SeedMembership(context);
        }

        private void SeedMembership(ABLeasing.Web.Infrastructure.ABLeasingDB context)
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                    "UserProfile", "UserId", "Email", autoCreateTables: true);
            }

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            var admins = new List<Staff>
            {
                new Staff { Name = "John", Email = "j@j.com"},
                new Staff { Name = "Matt", Email = "vallicgrr@gmail.com"},
                new Staff { Name = "John", Email = "mkteagle@gmail.com"},
                new Staff { Name = "Frank", Email = "vivoon29@gmail.com"},
            };

            string ADMIN = "Admin";

            if (!roles.RoleExists(ADMIN))
            {
                roles.CreateRole(ADMIN);
            }

            foreach (Staff admin in admins)
            {
                if (membership.GetUser(admin.Email, false) == null)
                {
                    WebSecurity.CreateUserAndAccount(admin.Email, "123456", new { Discriminator = "Staff", Name = admin.Name });
                }
                if (!roles.GetRolesForUser(admin.Email).Contains(ADMIN))
                {
                    roles.AddUsersToRoles(new[] { admin.Email }, new[] { ADMIN });
                }
            }
        }
    }
}
