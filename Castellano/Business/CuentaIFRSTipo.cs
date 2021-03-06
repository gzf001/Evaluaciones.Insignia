using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class CuentaIFRSTipo
	{
        public static CuentaIFRSTipo Get(string nombre)
        {
            return Query.GetCuentaIFRSTipos().SingleOrDefault<CuentaIFRSTipo>(x => x.Nombre == nombre);
        }

		public static List<CuentaIFRSTipo> GetAll()
		{
			return
				(
				from query in Query.GetCuentaIFRSTipos()
				select query
				).ToList<CuentaIFRSTipo>();
		}

        public static List<CuentaIFRSTipo> GetAll(CuentaIFRSTipoInforme tipoInforme)
        {
            return
                (
                from query in Query.GetCuentaIFRSTipos(tipoInforme)
                orderby query.Codigo
                select query
                ).ToList<CuentaIFRSTipo>();
        }
    }
}