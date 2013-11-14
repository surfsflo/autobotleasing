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

namespace ABLeasing.Web.Areas.Admin.Controllers
{
	[RouteArea("Admin")]
	[RoutePrefix("Equipment")]	
	public class EquipmentController : Controller
	{
		private ABLeasingDB db = new ABLeasingDB();

		[GET("")]
		public ActionResult Index()
		{
			var equipment = db.Equipment.Include(e => e.Category).Include(e => e.Lease).Include(e => e.Location);
			return View(equipment.ToList());
		}

		[GET("Details/{id}")]
		public ActionResult Details(int id = 0)
		{
			Equipment equipment = db.Equipment.Find(id);
			if (equipment == null)
			{
				return HttpNotFound();
			}
			return View(equipment);
		}

		[GET("Create")]
		public ActionResult Create()
		{
			ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "Name");
			ViewBag.EquipmentId = new SelectList(db.Leases, "LeaseId", "Name");
			ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "CellProvider");
			return View();
		}

		[POST("Create")]
		public ActionResult Create(Equipment equipment)
		{
			if (ModelState.IsValid)
			{
				db.Equipment.Add(equipment);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "Name", equipment.CategoryId);
			ViewBag.EquipmentId = new SelectList(db.Leases, "LeaseId", "Name", equipment.EquipmentId);
			ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "CellProvider", equipment.LocationId);
			return View(equipment);
		}

		[GET("Edit/{id}")]
		public ActionResult Edit(int id = 0)
		{
			Equipment equipment = db.Equipment.Find(id);
			if (equipment == null)
			{
				return HttpNotFound();
			}
			ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "Name", equipment.CategoryId);
			ViewBag.EquipmentId = new SelectList(db.Leases, "LeaseId", "Name", equipment.EquipmentId);
			ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "CellProvider", equipment.LocationId);
			return View(equipment);
		}

		[POST("Edit/{id}")]
		public ActionResult Edit(Equipment equipment)
		{
			if (ModelState.IsValid)
			{
				db.Entry(equipment).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.CategoryId = new SelectList(db.Categories, "CategoryID", "Name", equipment.CategoryId);
			ViewBag.EquipmentId = new SelectList(db.Leases, "LeaseId", "Name", equipment.EquipmentId);
			ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "CellProvider", equipment.LocationId);
			return View(equipment);
		}

		[GET("Delete/{id}")]
		public ActionResult Delete(int id = 0)
		{
			Equipment equipment = db.Equipment.Find(id);
			if (equipment == null)
			{
				return HttpNotFound();
			}
			return View(equipment);
		}

		[POST("Delete/{id}")]
		public ActionResult DeleteConfirmed(int id)
		{
			Equipment equipment = db.Equipment.Find(id);
			db.Equipment.Remove(equipment);
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