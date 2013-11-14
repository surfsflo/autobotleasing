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
using System.Data.Objects;

namespace ABLeasing.Web.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("Categories")]
    public class CategoriesController : Controller
    {
        private ABLeasingDB db = new ABLeasingDB();

        [GET("")]
        public ActionResult Index()
        {
            return PartialView(db.Categories.ToList());
        }

        [GET("Create")]
        public ActionResult Create()
        {
            return PartialView();
        }

        [POST("Create")]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView(category);
        }

        [GET("Edit/{id}")]
        public ActionResult Edit(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView(category);
        }

        [POST("Edit/{id}")]
        public ActionResult Edit(
            [Bind(Include = "Description,Name,CategoryID")]Category category)
        {
            if (ModelState.IsValid)
            {

                db.Entry(category).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return PartialView(category);
        }

        [GET("Delete/{id}")]
        public ActionResult Delete(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView(category);
        }

        [POST("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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