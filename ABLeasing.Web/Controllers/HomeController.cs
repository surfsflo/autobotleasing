using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting;
using AttributeRouting.Web.Mvc;

namespace ABLeasing.Web.Controllers
{
    [RoutePrefix("/")]
    public class HomeController : Controller
    {
        [GET("")]
        public ActionResult Index()
        {
            ViewBag.Title = "Index";

            return View();
        }

        [GET("Join")]
        public ActionResult Join()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
