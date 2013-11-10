using System.Web.Mvc;
using AttributeRouting;
using AttributeRouting.Web.Mvc;

namespace ABLeasing.Web.Controllers
{
    [RoutePrefix("Test")]
    public class BootstrapEditorTemplatesController : Controller
    {
        [GET("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
