using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castellano.Helpers
{
    public abstract class Controller : System.Web.Mvc.Controller
    {
        public Castellano.Membresia.Usuario CurrentUsuario
        {
            get
            {
                Castellano.Membresia.Usuario usuario = Castellano.Membresia.Usuario.Get(new Guid(this.User.Identity.Name));

                return usuario;
            }
        }

        public class ResponseModel
        {
            public bool Respuesta
            {
                get;
                set;
            }

            public string Redirect
            {
                get;
                set;
            }

            public string Error
            {
                get;
                set;
            }
        }
    }
}