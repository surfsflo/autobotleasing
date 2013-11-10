//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using AttributeRouting;
//using AttributeRouting.Web.Mvc;
//using ABLeasing.Web.Models;
//using ABLeasing.Web.Infrastructure;

//namespace ABLeasing.Web.Controllers
//{
//    [RoutePrefix("UserTest")]
//    public class UserTestController : Controller
//    {
//        ABLeasingDB db = new ABLeasingDB();
        
//        [GET("")]
//        public ActionResult Index()
//        {
//            return View(db.UserProfiles.ToList());
//        }

//        [GET("Details/{id}")]
//        public ActionResult Details(int id = 0)
//        {
//            UserProfile userprofile = db.UserProfiles.Find(id);
//            if (userprofile == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userprofile);
//        }

//        [GET("Create")]
//        public ActionResult Create()
//        {
//            return View();
//        }

//        [POST("Create")]
//        public ActionResult Create(UserProfile userprofile)
//        {
//            if (ModelState.IsValid)
//            {
//                db.UserProfiles.Add(userprofile);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(userprofile);
//        }

//        [GET("Edit/{id}")]
//        public ActionResult Edit(int id = 0)
//        {
//            UserProfile userprofile = db.UserProfiles.Find(id);
//            if (userprofile == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userprofile);
//        }

//        [POST("Edit/{id}")]
//        public ActionResult Edit(UserProfile userprofile)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(userprofile).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(userprofile);
//        }

//        [GET("Delete/{id}")]
//        public ActionResult Delete(int id = 0)
//        {
//            UserProfile userprofile = db.UserProfiles.Find(id);
//            if (userprofile == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userprofile);
//        }

//        [POST("Delete/{id}")]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            UserProfile userprofile = db.UserProfiles.Find(id);
//            db.UserProfiles.Remove(userprofile);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (db != null)
//            {
//                db.Dispose();
//            }

//            base.Dispose(disposing);
//        }
//    }
//}