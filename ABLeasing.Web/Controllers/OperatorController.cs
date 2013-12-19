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
using WebMatrix.WebData;
using ABLeasing.Web.Models.Accounts.ViewModels;
using System.Web.Security;

namespace ABLeasing.Web.Controllers
{
    [RoutePrefix("Operator")]
    public class OperatorController : ApplicationController
    {
        private readonly ABLeasingDB _db = new ABLeasingDB();


        [GET("Signup")]
        public ActionResult Signup()
        {
            return View();
        }

        [POST("Signup")]
        public ActionResult Signup(OperatorLogin viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(viewModel.Operator.Email, viewModel.RegisterModel.Password, new
                    {
                        Discriminator = "Operator",
                        Name = viewModel.Operator.Name
                    });
                    WebSecurity.Login(viewModel.Operator.Email, viewModel.RegisterModel.Password);

                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", AccountController.ErrorCodeToString(e.StatusCode));
                }
                var cl =
                    from s in _db.Operators
                    where s.Email == viewModel.Operator.Email
                    select s;

                var op = cl.First();

                op.Contact1 = viewModel.Operator.Contact1;
                op.TypeOfBusiness = viewModel.Operator.TypeOfBusiness;
                op.Description = viewModel.Operator.Description;
                _db.Entry(op).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index", "OperatorsView");
            }

            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}