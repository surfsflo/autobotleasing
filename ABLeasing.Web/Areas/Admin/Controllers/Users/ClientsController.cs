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
    [RoutePrefix("Clients")]
    public class ClientsController : Controller
    {
        private readonly ABLeasingDB _db = new ABLeasingDB();

        [GET("")]
        public ActionResult Index()
        {
            return View(_db.Clients.ToList());
        }

        [GET("Details/{id}")]
        public ActionResult Details(int id = 0)
        {
            Client client = _db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [GET("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [POST("Create")]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Clients.Add(client);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        [GET("Edit/{id}")]
        public ActionResult Edit(int id = 0)
        {
            Client client = _db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [POST("Edit/{id}")]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(client).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        [GET("Delete/{id}")]
        public ActionResult Delete(int id = 0)
        {
            Client client = _db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [POST("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = _db.Clients.Find(id);
            _db.Clients.Remove(client);
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