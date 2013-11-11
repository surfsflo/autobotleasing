﻿using System;
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
using WebMatrix.WebData;
using ABLeasing.Web.Models.Accounts.ViewModels;
using System.Web.Security;

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
        public ActionResult Create(OperatorLogin viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(viewModel.Operator.Email, viewModel.RegisterModel.Password);
                    WebSecurity.Login(viewModel.Operator.Email, viewModel.RegisterModel.Password);

                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", AccountController.ErrorCodeToString(e.StatusCode));
                }

                db.Operators.Add(viewModel.Operator);
                db.SaveChanges();

                return RedirectToAction("Index", "ClientsView");
            }

            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}