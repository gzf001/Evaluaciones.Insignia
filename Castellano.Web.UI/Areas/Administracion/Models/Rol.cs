using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Castellano.Web.UI.Areas.Administracion.Models
{
    public class Rol : Castellano.Membresia.Rol
    {
        public string Accion
        {
            get;
            set;
        }

        public class Roles
        {
            public List<Rol> data
            {
                get;
                set;
            }
        }
    }
}