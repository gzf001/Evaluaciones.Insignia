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
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult MisDatos()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult MisDatos(Castellano.Web.UI.Areas.Administracion.Models.Persona model)
        {
            return this.View();
        }

        public ActionResult Ciudades(string regionCodigo)
        {
            Castellano.Region region = Castellano.Region.Get(short.Parse(regionCodigo));

            return this.View(Castellano.Ciudad.GetAll(region));
        }

        [Authorize]
        [HttpGet]
        public ActionResult LogOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();

            this.Session.Abandon();

            return this.RedirectToAction("Login", "Home", new { area = string.Empty });
        }
    }
}