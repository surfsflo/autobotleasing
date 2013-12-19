using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABLeasing.Web.Models.ViewModels;
using AttributeRouting;
using AttributeRouting.Helpers;
using AttributeRouting.Web.Mvc;
using ABLeasing.Web.Models;
using ABLeasing.Web.Infrastructure;
using System.Data.Spatial;

namespace ABLeasing.Web.Controllers
{
    [RoutePrefix("Operators")]
    public class OperatorsViewController : ApplicationController
    {
        private readonly ABLeasingDB _db = new ABLeasingDB();

        [GET("LeaseApplication")]
        public ActionResult LeaseApplication()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            return View();
        }

        [POST("LeaseApplication")]
        public ActionResult LeaseApplication(LeaseApp viewModel)
        {

            var ops =
                from s in _db.Operators
                where s.Email == User.Identity.Name
                select s;

            int opId = ops.First().UserId;

            viewModel.Lease.OperatorId = opId;
            viewModel.Lease.Pending = true;


            if (ModelState.IsValid)
            {
                _db.Leases.Add(viewModel.Lease);
                viewModel.Equipment.LeaseId = viewModel.Lease.LeaseId;
                _db.Equipment.Add(viewModel.Equipment);

                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [GET("LeaseDetails/{id}")]
        public ActionResult LeaseDetails(int id = 0)
        {
            var lease = _db.Leases.Find(id);
            if (lease == null)
            {
                return Json(new
                {
                    error = new { msg = true }
                }, JsonRequestBehavior.AllowGet);
            }

            var jsonLease = new
            {
                Name = lease.Name,
                Leasers = "0",
                Amount = "$0.0",
                Equipment = lease.Equipment.Name,
                Latitude = lease.Location.GpsLocation.Latitude,
                Longitude = lease.Location.GpsLocation.Longitude,
                PrincipalAmount = lease.PrincipalAmount,
                InterestRaised = lease.InterestRate,
                ProfitShareRate = lease.ProfitShareRate
            };

            return Json(jsonLease, JsonRequestBehavior.AllowGet);
        }

        [GET("")]
        public ActionResult Index()
        {
            int opId = (int)ViewData["UserId"];

            var leases =
                from l in _db.Leases
                where l.OperatorId == opId
                select l;

            return View(leases);
        }

    }
}
