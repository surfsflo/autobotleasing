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

namespace ABLeasing.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("Lease")]
    public class LeaseController : Controller
    {
        private readonly ABLeasingDB _db = new ABLeasingDB();

        [GET("")]
        public ActionResult Index()
        {
            return View(_db.Leases.ToList());
        }

        [GET("Details/{id}")]
        public ActionResult Details(int id = 0)
        {
            Lease lease = _db.Leases.Find(id);
            if (lease == null)
            {
                return HttpNotFound();
            }
            return View(lease);
        }

        [GET("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [POST("Create")]
        public ActionResult Create(Lease lease)
        {
            if (ModelState.IsValid)
            {
                _db.Leases.Add(lease);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lease);
        }

        [GET("Edit/{id}")]
        public ActionResult Edit(int id = 0)
        {
            Lease lease = _db.Leases.Find(id);
            if (lease == null)
            {
                return HttpNotFound();
            }
            return View(lease);
        }

        [POST("Edit/{id}")]
        public ActionResult Edit(Lease lease)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(lease).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lease);
        }

        [GET("Delete/{id}")]
        public ActionResult Delete(int id = 0)
        {
            Lease lease = _db.Leases.Find(id);
            if (lease == null)
            {
                return HttpNotFound();
            }
            return View(lease);
        }

        [POST("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Lease lease = _db.Leases.Find(id);
            _db.Leases.Remove(lease);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}