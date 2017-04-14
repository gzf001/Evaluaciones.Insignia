using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Castellano.Web.UI.Models.Header
{
    public class Header
    {
        private Guid id;

        public Guid Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string UserName
        {
            get
            {
                Castellano.Persona persona = Castellano.Persona.Get(this.id);

                return string.Format("{0} {1} {2}", persona.Nombres, persona.ApellidoPaterno, string.IsNullOrEmpty(persona.ApellidoMaterno) ? persona.ApellidoMaterno : string.Empty);
            }
        }
    }
}