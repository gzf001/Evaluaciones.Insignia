using System.Web.Mvc;

namespace Castellano.Web.UI.Areas.Evaluaciones
{
    public class EvaluacionesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Evaluaciones";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Evaluaciones_default",
                "Evaluaciones/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}