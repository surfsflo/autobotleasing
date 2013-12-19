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

namespace ABLeasing.Web.Controllers
{

    public class PurchaseCooperativeController : ApplicationController
    {
        private readonly ABLeasingDB _db = new ABLeasingDB();

        [GET("")]
        public ActionResult Index()
        {
            return View(_db.PurchaseCooperatives.ToList());
        }

        [GET("Details/{id}")]
        public ActionResult Details(int id = 0)
        {
            PurchaseCooperative purchasecooperative = _db.PurchaseCooperatives.Find(id);
            if (purchasecooperative == null)
            {
                return HttpNotFound();
            }
            return View(purchasecooperative);
        }

        [GET("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [POST("Create")]
        public ActionResult Create(PurchaseCooperative purchasecooperative)
        {
            if (ModelState.IsValid)
            {
                _db.PurchaseCooperatives.Add(purchasecooperative);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchasecooperative);
        }

        [GET("Edit/{id}")]
        public ActionResult Edit(int id = 0)
        {
            PurchaseCooperative purchasecooperative = _db.PurchaseCooperatives.Find(id);
            if (purchasecooperative == null)
            {
                return HttpNotFound();
            }
            return View(purchasecooperative);
        }

        [POST("Edit/{id}")]
        public ActionResult Edit(PurchaseCooperative purchasecooperative)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(purchasecooperative).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchasecooperative);
        }

        [GET("Delete/{id}")]
        public ActionResult Delete(int id = 0)
        {
            PurchaseCooperative purchasecooperative = _db.PurchaseCooperatives.Find(id);
            if (purchasecooperative == null)
            {
                return HttpNotFound();
            }
            return View(purchasecooperative);
        }

        [POST("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseCooperative purchasecooperative = _db.PurchaseCooperatives.Find(id);
            _db.PurchaseCooperatives.Remove(purchasecooperative);
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