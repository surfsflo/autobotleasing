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

namespace ABLeasing.Web.Controllers.Signup
{
    [RoutePrefix("Signup/Operator")]
    public class OperatorController : Controller
    {
        private ABLeasingDB db = new ABLeasingDB();


        [GET("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [POST("Create")]
        public ActionResult Create(Operator oper)
        {
            if (ModelState.IsValid)
            {
                db.Operators.Add(oper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oper);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}