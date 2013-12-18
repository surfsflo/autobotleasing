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
        private readonly ABLeasingDB _db = new ABLeasingDB();

        [GET("LeaseApplication")]
        public ActionResult LeaseApplication()
        {
            ViewBag.EquipmentId
            return View();
        }

        [POST("LeaseApplication")]
        public ActionResult LeaseApplication(Lease lease)
        {

            var onlineOrders =
                from s in _db.Operators
                where s.Email == User.Identity.Name
                select s;
            int id = onlineOrders.First().UserId;

            if (ModelState.IsValid)
            {
                _db.Leases.Add(lease);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lease);
        }

        [GET("LeaseDetails")]
        public ActionResult LeaseDetails()
        {
            return View();
        }

        [GET("")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
