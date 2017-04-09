using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Castellano.Web.UI.Controllers.Header
{
    public class HeaderController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult _Index()
        {

            return this.View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult _Index(Castellano.Web.UI.Models.Header.Header model)
        {

            return this.View();
        }
    }
}
