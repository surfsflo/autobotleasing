using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using ABLeasing.Web.Models.Accounts;
using ABLeasing.Web.Infrastructure;

namespace ABLeasing.Web.Areas.Admin.Controllers.Users
{
    [RouteArea("Admin")]
    [RoutePrefix("Operators")]
    public class OperatorsController : Controller
    {
        private readonly ABLeasingDB _db = new ABLeasingDB();

        [GET("")]
        public ActionResult Index()
        {
            return PartialView(_db.Operators.ToList());
        }

        [GET("Details/{id}")]
        public ActionResult Details(int id = 0)
        {
            Operator op = _db.Operators.Find(id);
            if (op == null)
            {
                return HttpNotFound();
            }
            return PartialView(op);
        }

        [GET("Create")]
        public ActionResult Create()
        {
            return PartialView();
        }

        [POST("Create")]
        public ActionResult Create(Operator op)
        {
            if (ModelState.IsValid)
            {
                _db.Operators.Add(op);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView(op);
        }

        [GET("Edit/{id}")]
        public ActionResult Edit(int id = 0)
        {
            Operator op = _db.Operators.Find(id);
            if (op == null)
            {
                return HttpNotFound();
            }
            return PartialView(op);
        }

        [POST("Edit/{id}")]
        public ActionResult Edit(Operator op)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(op).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(op);
        }

        [GET("Delete/{id}")]
        public ActionResult Delete(int id = 0)
        {
            Operator op = _db.Operators.Find(id);
            if (op == null)
            {
                return HttpNotFound();
            }
            return PartialView(op);
        }

        [POST("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Operator op = _db.Operators.Find(id);
            _db.Operators.Remove(op);
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