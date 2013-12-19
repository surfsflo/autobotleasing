using System.Linq;
using System.Web.Mvc;
using ABLeasing.Web.Infrastructure;
using ABLeasing.Web.Models.Accounts;

namespace ABLeasing.Web.Controllers
{
    public abstract class ApplicationController : Controller
    {
        private readonly ABLeasingDB _db = new ABLeasingDB();

        protected ApplicationController()
        {

        }

        public UserProfile CurrentUser;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var users =
                    from u in _db.UserProfiles
                    where u.Email == requestContext.HttpContext.User.Identity.Name
                    select u;

                CurrentUser = users.First();
                ViewData["CurrentUser"] = CurrentUser;
                ViewData["UserId"] = CurrentUser.UserId;
            }
            else
                ViewData["CurrentUser"] = null;
        }

        public ABLeasingDB DataContext
        {
            get { return _db; }
        }
    }
}