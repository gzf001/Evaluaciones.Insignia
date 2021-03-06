using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
    public partial class TipoAdministracion
    {
        public static TipoAdministracion Corporacion
        {
            get
            {
                return Castellano.TipoAdministracion.Get(1);
            }
        }

        public static TipoAdministracion Direccion
        {
            get
            {
                return Castellano.TipoAdministracion.Get(2);
            }
        }

        public static TipoAdministracion Departamento
        {
            get
            {
                return Castellano.TipoAdministracion.Get(3);
            }
        }

        public static TipoAdministracion Get(int codigo)
        {
            return Query.GetTipoAdministraciones().SingleOrDefault<TipoAdministracion>(x => x.Codigo == codigo);
        }

        public static List<TipoAdministracion> GetAll()
        {
            return
                (
                from query in Query.GetTipoAdministraciones()
                select query
                ).ToList<TipoAdministracion>();
        }
    }
}