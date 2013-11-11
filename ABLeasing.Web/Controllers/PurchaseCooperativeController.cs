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
	[RoutePrefix("PurchaseCooperative")]	
    public class PurchaseCooperativeController : Controller
    {
        private ABLeasingDB db = new ABLeasingDB();

        [GET("")]
        public ActionResult Index()
        {
            return View(db.PurchaseCooperatives.ToList());
        }

        [GET("Details/{id}")]
        public ActionResult Details(int id = 0)
        {
            PurchaseCooperative purchasecooperative = db.PurchaseCooperatives.Find(id);
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
                db.PurchaseCooperatives.Add(purchasecooperative);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchasecooperative);
        }

        [GET("Edit/{id}")]
        public ActionResult Edit(int id = 0)
        {
            PurchaseCooperative purchasecooperative = db.PurchaseCooperatives.Find(id);
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
                db.Entry(purchasecooperative).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchasecooperative);
        }

        [GET("Delete/{id}")]
        public ActionResult Delete(int id = 0)
        {
            PurchaseCooperative purchasecooperative = db.PurchaseCooperatives.Find(id);
            if (purchasecooperative == null)
            {
                return HttpNotFound();
            }
            return View(purchasecooperative);
        }

        [POST("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseCooperative purchasecooperative = db.PurchaseCooperatives.Find(id);
            db.PurchaseCooperatives.Remove(purchasecooperative);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}