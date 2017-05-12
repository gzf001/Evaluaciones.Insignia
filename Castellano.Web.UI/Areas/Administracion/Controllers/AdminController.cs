using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
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

        #region Aplicaciones

        [Authorize]
        [HttpGet]
        public ActionResult Aplicaciones()
        {
            Castellano.Web.UI.Areas.Administracion.Models.Aplicacion model = new Castellano.Web.UI.Areas.Administracion.Models.Aplicacion();

            foreach (Castellano.Membresia.Perfil perfil in Castellano.Membresia.Perfil.GetAll())
            {
                model.Perfiles.Add(new SelectListItem
                {
                    Text = perfil.Nombre,
                    Value = perfil.Id.ToString()
                });
            }

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Aplicaciones(Castellano.Web.UI.Areas.Administracion.Models.Aplicacion model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Castellano.Membresia.Aplicacion aplicacion = Castellano.Membresia.Aplicacion.Get(model.Id);

            using (Castellano.Membresia.Context context = new Castellano.Membresia.Context())
            {
                foreach (Castellano.Membresia.Perfil perfil in Castellano.Membresia.Perfil.GetAll())
                {
                    new Castellano.Membresia.AplicacionPerfil
                    {
                        AplicacionId = model.Id,
                        PerfilId = perfil.Id
                    }.Delete(context);
                }

                context.SubmitChanges();
            }

            using (Castellano.Membresia.Context context = new Castellano.Membresia.Context())
            {
                new Castellano.Membresia.Aplicacion
                {
                    Id = model.Id,
                    MenuId = aplicacion == null ? default(Guid) : aplicacion.MenuId,
                    MenuItemId = aplicacion == null ? default(Guid) : aplicacion.MenuItemId,
                    Nombre = model.Nombre.Trim(),
                    Clave = model.Clave.Trim(),
                    Orden = model.Orden
                }.Save(context);

                foreach (Guid perfilId in model.SelectedPerfil)
                {
                    new Castellano.Membresia.AplicacionPerfil
                    {
                        AplicacionId = model.Id,
                        PerfilId = perfilId
                    }.Save(context);
                }

                context.SubmitChanges();
            }

            return this.Json("200 ok", JsonRequestBehavior.DenyGet);
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetAplicacion(Guid id)
        {
            Castellano.Membresia.Aplicacion aplicacion = Castellano.Membresia.Aplicacion.Get(id);

            List<Castellano.Membresia.AplicacionPerfil> aplicacionPerfiles = Castellano.Membresia.AplicacionPerfil.GetAll(aplicacion);

            return this.Json(new Castellano.Web.UI.Areas.Administracion.Models.Aplicacion
            {
                Id = aplicacion.Id,
                Nombre = aplicacion.Nombre,
                Clave = aplicacion.Clave,
                Orden = aplicacion.Orden,
                SelectedPerfil = aplicacionPerfiles.Any() ? aplicacionPerfiles.Select<Castellano.Membresia.AplicacionPerfil, Guid>(x => x.PerfilId).ToList<Guid>() : null
            }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public JsonResult DeleteAplicacion(Guid id)
        {
            Castellano.Membresia.Aplicacion aplicacion = Castellano.Membresia.Aplicacion.Get(id);

            using (Castellano.Membresia.Context context = new Castellano.Membresia.Context())
            {
                new Castellano.Membresia.Aplicacion
                {
                    Id = aplicacion.Id,
                    MenuId = aplicacion.MenuId,
                    MenuItemId = aplicacion.MenuItemId,
                    Nombre = aplicacion.Nombre,
                    Clave = aplicacion.Clave,
                    Orden = aplicacion.Orden
                }.Delete(context);

                context.SubmitChanges();
            }

            return this.Json("200 ok", JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetAplicaciones()
        {
            Castellano.Web.UI.Areas.Administracion.Models.Aplicacion.Aplicaciones aplicaciones = new Castellano.Web.UI.Areas.Administracion.Models.Aplicacion.Aplicaciones();

            aplicaciones.data = new List<Castellano.Web.UI.Areas.Administracion.Models.Aplicacion>();

            foreach (Castellano.Membresia.Aplicacion aplicacion in Castellano.Membresia.Aplicacion.GetAll())
            {
                aplicaciones.data.Add(new Castellano.Web.UI.Areas.Administracion.Models.Aplicacion
                {
                    Id = aplicacion.Id,
                    Nombre = aplicacion.Nombre,
                    Clave = aplicacion.Clave,
                    Orden = aplicacion.Orden,
                    Accion = string.Format("{0}{1}", Castellano.Helpers.ActionLinkExtension.ActionLinkEmbedded(aplicacion.Id, null, Castellano.Helpers.TypeButton.Edit),
                                                     Castellano.Helpers.ActionLinkExtension.ActionLinkEmbedded(aplicacion.Id, null, Castellano.Helpers.TypeButton.Delete))
                });
            }

            return this.Json(aplicaciones, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Ítems de menú

        [Authorize]
        [HttpGet]
        public ActionResult ItemsMenu()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ItemsMenu(Castellano.Web.UI.Areas.Administracion.Models.MenuItem model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
                Castellano.Membresia.MenuItem menuItem = Castellano.Membresia.MenuItem.Get(model.AplicacionId, Castellano.Membresia.Menu.MenuPrincipal.Id, model.Id);

                using (Castellano.Membresia.Context context = new Castellano.Membresia.Context())
                {
                    Castellano.Membresia.MenuItem m = new Castellano.Membresia.MenuItem
                    {
                        AplicacionId = model.AplicacionId,
                        MenuId = Castellano.Membresia.Menu.MenuPrincipal.Id,
                        Id = model.Id,
                        MenuItemId = model.MenuItemId,
                        Nombre = model.Nombre,
                        Informacion = model.Informacion,
                        Icono = model.Icono,
                        Url = model.Url,
                        Visible = model.Visible,
                        MuestraMenus = model.MuestraMenus
                    };

                    if (menuItem == null)
                    {
                        menuItem = Castellano.Membresia.MenuItem.Get(model.AplicacionId, Castellano.Membresia.Menu.MenuPrincipal.Id, model.MenuItemId.Value);

                        m.Orden = Castellano.Membresia.MenuItem.Last(menuItem);
                    }
                    else
                    {
                        m.Orden = menuItem.Orden;
                    }

                    m.Save(context);

                    foreach (Castellano.Membresia.Accion accion in Castellano.Membresia.Accion.GetAll())
                    {
                        new Castellano.Membresia.MenuItemAccion
                        {
                            AplicacionId = model.AplicacionId,
                            MenuId = Castellano.Membresia.Menu.MenuPrincipal.Id,
                            MenuItemId = model.Id,
                            AccionCodigo = accion.Codigo
                        }.Save(context);
                    }

                    context.SubmitChanges();
                }

                return this.View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet]
        public JsonResult DeleteItemsMenu(Guid aplicacionId, Guid itemId)
        {
            try
            {
                Castellano.Membresia.MenuItem menuItem = Castellano.Membresia.MenuItem.Get(aplicacionId, Castellano.Membresia.Menu.MenuPrincipal.Id, itemId);

                using (Castellano.Membresia.Context context = new Castellano.Membresia.Context())
                {
                    foreach (Castellano.Membresia.MenuItem m in Castellano.Membresia.MenuItem.GetAll(menuItem))
                    {
                        new Castellano.Membresia.MenuItem
                        {
                            AplicacionId = m.AplicacionId,
                            MenuId = m.MenuId,
                            Id = m.Id,
                            MenuItemId = m.MenuItemId,
                            Nombre = m.Nombre,
                            Informacion = m.Informacion,
                            Icono = m.Icono,
                            Url = m.Url,
                            Visible = m.Visible,
                            MuestraMenus = m.MuestraMenus
                        }.Delete(context);

                        context.SubmitChanges();
                    }

                    new Castellano.Membresia.MenuItem
                    {
                        AplicacionId = menuItem.AplicacionId,
                        MenuId = menuItem.MenuId,
                        Id = menuItem.Id,
                        MenuItemId = menuItem.MenuItemId,
                        Nombre = menuItem.Nombre,
                        Informacion = menuItem.Informacion,
                        Icono = menuItem.Icono,
                        Url = menuItem.Url,
                        Visible = menuItem.Visible,
                        MuestraMenus = menuItem.MuestraMenus
                    }.Delete(context);

                    context.SubmitChanges();
                }

                return this.Json("200 ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetOrder(string data)
        {
            Castellano.Membresia.MenuItem.OrderMenu(data);

            return this.Json("200 ok", JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetItemMenu(Guid aplicacionId, Guid itemId)
        {
            Castellano.Membresia.MenuItem menuItem = Castellano.Membresia.MenuItem.Get(aplicacionId, Castellano.Membresia.Menu.MenuPrincipal.Id, itemId);

            Castellano.Web.UI.Areas.Administracion.Models.MenuItem m = new Castellano.Web.UI.Areas.Administracion.Models.MenuItem
            {
                NombreAplicacion = menuItem.Aplicacion.Nombre,
                Nombre = menuItem.Nombre,
                Informacion = menuItem.Informacion,
                Url = menuItem.Url,
                Visible = menuItem.Visible
            };

            return this.Json(m, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetItemsMenu(Guid aplicacionId)
        {
            Castellano.Membresia.Aplicacion aplicacion = Castellano.Membresia.Aplicacion.Get(aplicacionId);

            return this.Json(Castellano.Helpers.MenuExtension.MenuOrderable(null, aplicacion).ToString(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Roles

        [Authorize]
        [HttpGet]
        public ActionResult Roles()
        {
            
            return this.View();
        }

        #endregion

        [Authorize]
        [HttpGet]
        public ActionResult Auditoria()
        {
            return this.View();
        }
    }
}