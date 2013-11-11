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
using ABLeasing.Web.Models;
using WebMatrix.WebData;
using System.Web.Security;
using ABLeasing.Web.Models.Accounts.ViewModels;

namespace ABLeasing.Web.Controllers.Signup
{
    [RoutePrefix("Signup/Client")]	
    public class ClientController : Controller
    {
        private ABLeasingDB db = new ABLeasingDB();


        [GET("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [POST("Create")]
        public ActionResult Create(ClientLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(viewModel.Client.Email, viewModel.RegisterModel.Password);
                    WebSecurity.Login(viewModel.Client.Email, viewModel.RegisterModel.Password);

                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", AccountController.ErrorCodeToString(e.StatusCode));
                }          

                db.Clients.Add(viewModel.Client);
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