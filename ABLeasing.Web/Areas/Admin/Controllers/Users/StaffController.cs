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
    [RoutePrefix("Staff")]
    public class StaffController : Controller
    {
        private readonly ABLeasingDB _db = new ABLeasingDB();

        [GET("")]
        public ActionResult Index()
        {
            return View(_db.Staff.ToList());
        }

        [GET("Details/{id}")]
        public ActionResult Details(int id = 0)
        {
            Staff staff = _db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        [GET("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [POST("Create")]
        public ActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _db.Staff.Add(staff);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        [GET("Edit/{id}")]
        public ActionResult Edit(int id = 0)
        {
            Staff staff = _db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        [POST("Edit/{id}")]
        public ActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(staff).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        [GET("Delete/{id}")]
        public ActionResult Delete(int id = 0)
        {
            Staff staff = _db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        [POST("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = _db.Staff.Find(id);
            _db.Staff.Remove(staff);
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