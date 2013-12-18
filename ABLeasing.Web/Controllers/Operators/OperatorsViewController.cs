﻿using System;
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
using System.Data.Spatial;

namespace ABLeasing.Web.Controllers.Operators
{
    [RoutePrefix("OperatorsView")]
    public class OperatorsViewController : Controller
    {
        private readonly ABLeasingDB _db = new ABLeasingDB();

        [GET("LeaseApplication")]
        public ActionResult LeaseApplication()
        {
            ViewBag.EquipmentId = new SelectList(_db.Equipment, "EquipmentId", "Name");
            return View();
        }

        [POST("LeaseApplication")]
        public ActionResult LeaseApplication(Lease lease)
        {

            var ops =
                from s in _db.Operators
                where s.Email == User.Identity.Name
                select s;

            int opId = ops.First().UserId;

            lease.OperatorId = opId;
            lease.Pending = true;
            lease.LeaseId = lease.EquipmentId;
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
