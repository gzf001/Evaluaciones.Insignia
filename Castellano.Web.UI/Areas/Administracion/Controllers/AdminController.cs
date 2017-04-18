using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Castellano.Web.UI.Areas.Administracion.Controllers
{
    public class AdminController : Castellano.Helpers.Controller
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
            Castellano.Persona persona = Castellano.Persona.Get(new Guid(this.User.Identity.Name));

            Castellano.Web.UI.Areas.Administracion.Models.Persona model = new Castellano.Web.UI.Areas.Administracion.Models.Persona
            {
                Id = persona.Id,
                Run = persona.Run,
                RunCuerpo = persona.RunCuerpo,
                RunDigito = persona.RunDigito,
                Nombres = persona.Nombres,
                ApellidoPaterno = persona.ApellidoPaterno,
                ApellidoMaterno = persona.ApellidoMaterno,
                Email = persona.Email,
                SexoCodigo = persona.SexoCodigo,
                FechaNacimiento = persona.FechaNacimiento,
                NacionalidadCodigo = persona.NacionalidadCodigo,
                EstadoCivilCodigo = persona.EstadoCivilCodigo,
                NivelEducacionalCodigo = persona.NivelEducacionalCodigo,
                RegionCodigo = persona.RegionCodigo,
                CiudadCodigo = persona.CiudadCodigo,
                ComunaCodigo = persona.ComunaCodigo,
                VillaPoblacion = persona.VillaPoblacion,
                Direccion = persona.Direccion,
                Telefono = persona.Telefono,
                Celular = persona.Celular,
                Observaciones = persona.Observaciones,
                Ocupacion = persona.Ocupacion,
                TelefonoLaboral = persona.TelefonoLaboral,
                DireccionLaboral = persona.DireccionLaboral,
            };

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult MisDatos(Castellano.Web.UI.Areas.Administracion.Models.Persona model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string run = model.Run.Replace(".", string.Empty).Replace("-", string.Empty);

            int runCuerpo;

            if (!int.TryParse(run.Substring(0, run.Length - 1), out runCuerpo))
            {
                this.ModelState.AddModelError("errorRunCuerpo", "El R.U.N. es erróneo");

                return this.View(model);
            }

            char runDigito = char.Parse(run.Replace(runCuerpo.ToString(), string.Empty));

            if (!Castellano.Helper.ValidaRun(runCuerpo, runDigito))
            {
                this.ModelState.AddModelError("errorRunCuerpo", "El R.U.N. es erróneo");

                return this.View(model);
            }

            try
            {
                using (Castellano.Context context = new Castellano.Context())
                {
                    new Castellano.Persona
                    {
                        Id = this.CurrentUsuario.Id,
                        RunCuerpo = runCuerpo,
                        RunDigito = runDigito,
                        Nombres = model.Nombres,
                        ApellidoPaterno = model.ApellidoPaterno,
                        ApellidoMaterno = string.IsNullOrEmpty(model.ApellidoMaterno) ? default(string) : model.ApellidoMaterno.Trim(),
                        Email = string.IsNullOrEmpty(model.Email) ? default(string) : model.Email.Trim(),
                        SexoCodigo = model.SexoCodigo,
                        FechaNacimiento = model.FechaNacimiento.HasValue ? model.FechaNacimiento.Value : default(DateTime),
                        NacionalidadCodigo = model.NacionalidadCodigo.HasValue ? model.NacionalidadCodigo.Value : default(short),
                        EstadoCivilCodigo = model.EstadoCivilCodigo.HasValue ? model.EstadoCivilCodigo.Value : default(short),
                        NivelEducacionalCodigo = model.NivelEducacionalCodigo.HasValue ? model.NivelEducacionalCodigo.Value : default(int),
                        RegionCodigo = model.RegionCodigo.HasValue ? model.RegionCodigo.Value : default(short),
                        CiudadCodigo = model.CiudadCodigo.HasValue ? model.CiudadCodigo.Value : default(short),
                        ComunaCodigo = model.ComunaCodigo.HasValue ? model.ComunaCodigo.Value : default(short),
                        VillaPoblacion = string.IsNullOrEmpty(model.VillaPoblacion) ? default(string) : model.VillaPoblacion.Trim(),
                        Direccion = string.IsNullOrEmpty(model.Direccion) ? default(string) : model.Direccion.Trim(),
                        Telefono = model.Telefono.HasValue ? model.Telefono.Value : default(int),
                        Celular = model.Celular.HasValue ? model.Celular.Value : default(int),
                        Observaciones = string.IsNullOrEmpty(model.Observaciones) ? default(string) : model.Observaciones.Trim(),
                        Ocupacion = string.IsNullOrEmpty(model.Ocupacion) ? default(string) : model.Ocupacion.Trim(),
                        TelefonoLaboral = model.TelefonoLaboral.HasValue ? model.TelefonoLaboral.Value : default(int),
                        DireccionLaboral = string.IsNullOrEmpty(model.DireccionLaboral) ? default(string) : model.DireccionLaboral.Trim(),
                    }.Save(context);

                    context.SubmitChanges();
                }

                this.ViewBag.Message = "Sus información ha sido guardada correctamente!";

                return this.View(model);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UK_Persona_RunCuerpo"))
                {
                    this.ModelState.AddModelError("errorRun", "El R.U.N. ingresado se encuentra registrado para otro usuario");

                    return this.View(model);
                }
                else
                {
                    this.ModelState.AddModelError("errorGeneral", ex.Message);

                    return this.View(model);
                }
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(Castellano.Web.UI.Areas.Administracion.Models.ChangePassword model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string password = Castellano.Membresia.Account.EncryptPassword(model.Password);

            if (!this.CurrentUsuario.Password.Equals(password))
            {
                this.ModelState.AddModelError("errorPassword", "La contraseña actual no es correcta");

                return this.View(model);
            }

            Castellano.Membresia.Account.DoChangePassword(this.CurrentUsuario, model.Password1, model.Password2);

            this.ViewBag.Message = "Sus contraseña fue cambiada correctamente!";

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
        public ActionResult About()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult LogOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();

            this.Session.Abandon();

            return this.RedirectToAction("Login", "Home", new { area = string.Empty });
        }

        [Authorize]
        [HttpGet]
        public ActionResult Aplicaciones()
        {
            return this.View();
        }
    }
}