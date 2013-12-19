using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AttributeRouting;
using AttributeRouting.Web.Mvc;
using ABLeasing.Web.Models;
using ABLeasing.Web.Infrastructure;
using ABLeasing.Web.HtmlHelpers;

namespace ABLeasing.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("Equipment")]
    public class EquipmentController : Controller
    {
        private readonly ABLeasingDB _db = new ABLeasingDB();

        [GET("")]
        public ActionResult Index()
        {
            var sa = from s in _db.Equipment
                     select s;

            var equipment = sa.ToList();
            return View(equipment);
        }

        [GET("Details/{id}")]
        public ActionResult Details(int id = 0)
        {
            Equipment equipment = _db.Equipment.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return View(equipment);
        }

        [GET("Create")]
        public ActionResult Create()
        {
            //            var cats = _db.Categories
            ViewBag.CategoryId = new SelectList(_db.Categories.OrderBy(x => x.Name), "CategoryId", "Name");
            return View();
        }

        [POST("Create")]
        public ActionResult Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _db.Equipment.Add(equipment);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name", equipment.CategoryId);
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "CellProvider", equipment.LocationId);
            return View(equipment);
        }

        [GET("Edit/{id}")]
        public ActionResult Edit(int id = 0)
        {
            Equipment equipment = _db.Equipment.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_db.Categories.OrderBy(m => m.Name), "CategoryId", "Name", equipment.CategoryId);
            return View(equipment);
        }

        [POST("Edit/{id}")]
        public ActionResult Edit(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(equipment).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_db.Categories.OrderBy(m => m.Name), "CategoryId", "Name", equipment.CategoryId);
            return View(equipment);
        }

        [GET("Delete/{id}")]
        public ActionResult Delete(int id = 0)
        {
            Equipment equipment = _db.Equipment.Find(id);
            if (equipment == null)
            {
                return HttpNotFound();
            }
            return PartialView(equipment);
        }

        [POST("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipment equipment = _db.Equipment.Find(id);
            _db.Equipment.Remove(equipment);
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