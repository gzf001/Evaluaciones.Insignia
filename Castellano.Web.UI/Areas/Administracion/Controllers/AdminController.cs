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
        [HttpPost]
        public ActionResult MisDatos(Castellano.Web.UI.Areas.Administracion.Models.Persona model)
        {
            using(Castellano.Context context = new Castellano.Context())
            {
                string run = model.Run.Replace(".", string.Empty).Replace("-", string.Empty);

            }

            return this.View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Ciudades(string regionCodigo)
        {
            Castellano.Region region = Castellano.Region.Get(short.Parse(regionCodigo));

            List<Castellano.Ciudad> ciudades = Castellano.Ciudad.GetAll(region);

            SelectList selectList = new SelectList(ciudades, "Codigo", "Nombre");

            IEnumerable<SelectListItem> defaultItem = Enumerable.Repeat(new SelectListItem
            {
                Value = "-1",
                Text = "[Seleccione]"
            }, count: 1);

            return this.Json(defaultItem.Concat(selectList), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Comunas(string regionCodigo, string ciudadCodigo)
        {
            Castellano.Ciudad ciudad = Castellano.Ciudad.Get(short.Parse(regionCodigo), short.Parse(ciudadCodigo));

            List<Castellano.Comuna> comunas = Castellano.Comuna.GetAll(ciudad);

            SelectList selectList = new SelectList(comunas, "Codigo", "Nombre");

            IEnumerable<SelectListItem> defaultItem = Enumerable.Repeat(new SelectListItem
            {
                Value = "-1",
                Text = "[Seleccione]"
            }, count: 1);

            return this.Json(defaultItem.Concat(selectList), JsonRequestBehavior.AllowGet);
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