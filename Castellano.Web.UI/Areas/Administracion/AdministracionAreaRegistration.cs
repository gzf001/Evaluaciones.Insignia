using System.Web.Mvc;

namespace Castellano.Web.UI.Areas.Administracion
{
    public class AdministracionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administracion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            #region Ciudades

            context.MapRoute("Ciudades", "Administracion/Admin/Ciudades/{regionCodigo}", new { controller = "Admin", action = "Ciudades", regionCodigo = "" });

            #endregion

            context.MapRoute(
                "Administracion_default",
                "Administracion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
