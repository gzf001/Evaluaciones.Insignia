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
            #region Ciudades y Comunas

            context.MapRoute(
                name: "Ciudades",
                url: "Administracion/Admin/Ciudades/{regionCodigo}",
                defaults: new { area = "Administracion", controller = "Admin", action = "Ciudades", regionCodigo = "" }
            );

            context.MapRoute(
                name: "Comunas",
                url: "Administracion/Admin/Comunas/{regionCodigo}/{ciudadCodigo}",
                defaults: new { area = "Administracion", controller = "Admin", action = "Comunas", regionCodigo = "", ciudadCodigo = "" }
            );

            #endregion

            context.MapRoute(
                "Administracion_default",
                "Administracion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
