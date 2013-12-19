using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABLeasing.Web.Infrastructure;
using ABLeasing.Web.Models;
using ABLeasing.Web.Models.Accounts;
using ABLeasing.Web.Models.ViewModels;
using AttributeRouting;
using AttributeRouting.Helpers;
using AttributeRouting.Web.Mvc;
using TwitterBootstrapMVC;

namespace ABLeasing.Web.Controllers
{
    [RoutePrefix("Clients")]
    public class ClientsViewController : ApplicationController
    {

        private readonly ABLeasingDB _db = new ABLeasingDB();

        [GET("")]
        public ActionResult Index()
        {

            var leases = _db.Leases.Where(x => !x.Pending);

            return View(leases);
        }

        [GET("Join/{id}")]
        public ActionResult Join(int id = 0)
        {
            var lease = _db.Leases.Find(id);
            if (lease == null)
            {
                return HttpNotFound();
            }

            var clientId = (int)ViewData["UserId"];
            var client = _db.Clients.Find(clientId);

            var pc = _db.PurchaseCooperatives.Find(lease.LeaseId);
            if (pc == null)
            {
                ViewBag.PC = false;
            }
            else
            {
                ViewBag.PC = true;
                ViewBag.Counts = pc.Clients.Count();
            }

            var viewModel = new JoinLeaseViewModel()
            {
                Client = client,
                Lease = lease
            };

            return View(viewModel);
        }

        [POST("Join/{id}")]
        public ActionResult Join(JoinLeaseViewModel viewModel)
        {


            var clientId = (int)ViewData["UserId"];
            var client = _db.Clients.Find(viewModel.Client.UserId);
            var lease = viewModel.Lease;
            client.DepositAmount += viewModel.Client.DepositAmount;

            var pc = new PurchaseCooperative();
            pc.Clients = new List<Client>();
            pc.Clients.Add(client);
            pc.Lease = lease;
            pc.AmountFinanced = 0;

            pc.AmountFinanced += viewModel.Client.DepositAmount;


            _db.PurchaseCooperatives.Add(pc);
            _db.SaveChanges();

            return RedirectToAction("Index");

            //            return View(viewModel);
        }

    }
}
