using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABLeasing.Web.Infrastructure;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using TwitterBootstrapMVC;

namespace ABLeasing.Web.Controllers
{
    [RoutePrefix("Clients")]
    public class ClientsViewController : ApplicationController
    {

        private readonly ABLeasingDB _db = new ABLeasingDB();

        [GET("")]
        public ActionResult Index()
        {

            var leases = _db.Leases.Where(x => !x.Pending);

            return View(leases);
        }

        [GET("Join/{id}")]
        public ActionResult Join()
        {

            return View();
        }

    }
}
