using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Castellano.Web.UI.Areas.Administracion.Controllers
{
    public class AdminController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public ActionResult LogOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();

            this.Session.Abandon();

            return this.RedirectToAction("Login", "Home", new { area = string.Empty });
        }
    }
}
