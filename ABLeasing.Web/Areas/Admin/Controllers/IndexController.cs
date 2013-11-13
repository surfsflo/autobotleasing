using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting;
using AttributeRouting.Web.Mvc;

namespace ABLeasing.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea("Admin", Subdomain = "admin")]
    public class IndexController : Controller
    {
        [GET("")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
