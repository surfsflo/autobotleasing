using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
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

namespace ABLeasing.Web.Controllers
{

    public class ClientController : Controller
    {
        private readonly ABLeasingDB _db = new ABLeasingDB();


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
                    WebSecurity.CreateUserAndAccount(viewModel.Client.Email, viewModel.RegisterModel.Password, new
                    {
                        Discriminator = "Client",
                        Name = viewModel.Client.Name
                    });
                    WebSecurity.Login(viewModel.Client.Email, viewModel.RegisterModel.Password);

                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", AccountController.ErrorCodeToString(e.StatusCode));
                }

                var cl =
                    from s in _db.Clients
                    where s.Email == viewModel.Client.Email
                    select s;

                var client = cl.First();

                client.Name = viewModel.Client.Name;
                client.Contact1 = viewModel.Client.Contact1;
                client.Status = true;
                client.Frequency = DepositFrequency.NotSet;
                client.AutoPay = false;
                _db.Entry(client).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index", "ClientsView");
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