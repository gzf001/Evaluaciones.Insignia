using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class CuentaIFRSSubTipo
	{
        public static CuentaIFRSSubTipo Get(string nombre)
        {
            return Query.GetCuentaIFRSSubTipos().SingleOrDefault<CuentaIFRSSubTipo>(x => x.Descripcion == nombre);
        }

        public static CuentaIFRSSubTipo Get(CuentaIFRSTipo tipo, string nombre)
        {
            return Query.GetCuentaIFRSSubTipos(tipo).SingleOrDefault<CuentaIFRSSubTipo>(x => x.Descripcion == nombre);
        }

		public static List<CuentaIFRSSubTipo> GetAll()
		{
			return
				(
				from query in Query.GetCuentaIFRSSubTipos()
				select query
				).ToList<CuentaIFRSSubTipo>();
		}

        public static List<CuentaIFRSSubTipo> GetAll(CuentaIFRSTipo tipoCuenta)
        {
            return
                (
                from query in Query.GetCuentaIFRSSubTipos(tipoCuenta)
                orderby query.Codigo
                select query
                ).ToList<CuentaIFRSSubTipo>();
        }

    }
}