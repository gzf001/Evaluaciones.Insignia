using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class CuentaIFRSClasificacion
	{
        public static CuentaIFRSClasificacion Get(string nombre)
        {
            return Query.GetCuentaIFRSClasificaciones().SingleOrDefault<CuentaIFRSClasificacion>(x => x.Nombre == nombre);
        }

        public static CuentaIFRSClasificacion Get(CuentaIFRSSubTipo sub, string nombre)
        {
            return Query.GetCuentaIFRSClasificaciones(sub).SingleOrDefault<CuentaIFRSClasificacion>(x => x.Nombre == nombre);
        }

		public static List<CuentaIFRSClasificacion> GetAll()
		{
			return
				(
				from query in Query.GetCuentaIFRSClasificaciones()
				select query
				).ToList<CuentaIFRSClasificacion>();
		}

        public static List<CuentaIFRSClasificacion> GetAll(CuentaIFRSSubTipo subTipo)
        {
            return
                  (
                  from query in Query.GetCuentaIFRSClasificaciones(subTipo)
                  orderby query.Codigo
                  select query
                  ).ToList<CuentaIFRSClasificacion>();
        }
    }
}