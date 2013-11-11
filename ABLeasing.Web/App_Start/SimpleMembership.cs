using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace ABLeasing.Web.App_Start
{
    public static class SimpleMembership
    {
        public static void Register()
        {
            if (!WebSecurity.Initialized)
            {
                //WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "Email", autoCreateTables: true);
            }
        }
    }
}