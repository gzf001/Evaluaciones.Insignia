using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Castellano.Web.UI.Areas.Administracion.Models
{
    public class Aplicacion : Castellano.Membresia.Aplicacion
    {
        public string Accion
        {
            get;
            set;
        }

        public class Aplicaciones
        {
            public List<Aplicacion> data
            {
                get;
                set;
            }
        }
    }
}