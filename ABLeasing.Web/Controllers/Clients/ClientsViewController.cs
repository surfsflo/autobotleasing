using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting;
using AttributeRouting.Web.Mvc;

namespace ABLeasing.Web.Controllers.Clients
{
	[RoutePrefix("ClientsView")]
    public class ClientsViewController : Controller
    {
		[GET("")]
        public ActionResult Index()
        {
            return View();
        }
     
    }
}
