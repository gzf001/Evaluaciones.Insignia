using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Castellano.Web.UI.Controllers.Home
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return this.View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Castellano.Web.UI.Models.Home.Login model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string textoRun = model.RUN.Replace(".", string.Empty).Replace("-", string.Empty);

            int runCuerpo = int.Parse(textoRun.Substring(0, textoRun.Length - 1));
            char runDigito = char.Parse(textoRun.Replace(runCuerpo.ToString(), string.Empty));

            Castellano.Membresia.LoginStatus loginStatus = Castellano.Membresia.Account.DoLogin(runCuerpo, runDigito, model.Password);

            if (loginStatus == Castellano.Membresia.LoginStatus.InvalidRunOrPassword)
            {
                this.ModelState.AddModelError("loginError", "R.U.N. o contraseña incorrectos. Verifique sus datos e inténte acceder nuevamente.");

                return this.View(model);
            }
            else if (loginStatus == Castellano.Membresia.LoginStatus.NotAccessAllowed)
            {
                this.ModelState.AddModelError("loginError", "Usted no tiene suficientes permisos para ingresar a la aplicación. Por favor contacte al administrador.");

                return this.View(model);
            }
            else if (loginStatus == Castellano.Membresia.LoginStatus.UserApprovedOut)
            {
                this.ModelState.AddModelError("loginError", "Su cuenta de acceso a sido caducada. Por favor contacte al administrador del sistema.");

                return this.View(model);
            }
            else if (loginStatus == Castellano.Membresia.LoginStatus.UserLocked)
            {
                this.ModelState.AddModelError("loginError", "Su cuenta de acceso a sido bloqueada por exceder el máximo de intentos fallidos permitidos.");

                return this.View(model);
            }

            //Castellano.Web.UI.Models.Header.Header.Run = textoRun;

            Castellano.Web.UI.Models.Header.Header header = new Castellano.Web.UI.Models.Header.Header
            {
                Run = textoRun,
                UserName = "Guillermo Zuleta Flores"
            };

            this.ViewBag.Header = header;
            //this.ViewBag.Header = Castellano.Web.UI.Models.Header.Header.Run = textoRun;

            System.Web.Security.FormsAuthentication.SetAuthCookie(model.RUN, model.RememberMe);

            return this.RedirectToAction("Index", "Admin", new { area = "Administracion" });
        }

        public ActionResult RecoveryPass()
        {
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RecoveryPass(Castellano.Web.UI.Models.Home.RecoveryPass model)
        {
            return this.View();
        }
    }
}