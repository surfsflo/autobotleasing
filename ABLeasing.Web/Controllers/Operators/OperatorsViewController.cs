using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using ABLeasing.Web.Models;
using ABLeasing.Web.Infrastructure;

namespace ABLeasing.Web.Controllers.Operators
{
	[RoutePrefix("OperatorsView")]
    public class OperatorsViewController : Controller
    {
        private ABLeasingDB db = new ABLeasingDB();

        [GET("LeaseApplication")]
        public ActionResult LeaseApplication() {
            return View();
        }

        [POST("LeaseApplication")]
        public ActionResult LeaseApplication(Lease lease) {
            if (ModelState.IsValid) {
                db.Leases.Add(lease);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lease);
        }

        [GET("LeaseDetails")]
        public ActionResult LeaseDetails() {
            return View();
        }

		[GET("")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
