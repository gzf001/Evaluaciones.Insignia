using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class CuentaIFRS
	{
        public static CuentaIFRS Get(string nombre)
        {
            return Query.GetCuentaIFRSes().SingleOrDefault<CuentaIFRS>(x => x.Descripcion == nombre);
        }

        public static CuentaIFRS Get(string nombre, int ano)
        {
            return Query.GetCuentaIFRSes(ano).SingleOrDefault<CuentaIFRS>(x => x.Descripcion == nombre);
        }

        public static CuentaIFRS Get(CuentaIFRSTipoInforme tipoInforme, Empresa empresa, Ano anio, string nombre)
        {
            return Query.GetCuentaIFRSes(empresa, anio, tipoInforme).SingleOrDefault<CuentaIFRS>(x => x.Descripcion == nombre);
        }

        public static CuentaIFRS Get(Empresa empresa, Ano anio, string nombre)
        {
            return Query.GetCuentaIFRSes(empresa, anio).SingleOrDefault<CuentaIFRS>(x => x.Descripcion == nombre);
        }

		public static List<CuentaIFRS> GetAll()
		{
			return
				(
				from query in Query.GetCuentaIFRSes()
				select query
				).ToList<CuentaIFRS>();
		}

        public static List<CuentaIFRS> GetAll(CuentaIFRSTipoInforme tipoInforme)
        {
            return
                 (
                 from query in Query.GetCuentaIFRSes(tipoInforme)
                 orderby query.CodigoCuenta
                 select query
                 ).ToList<CuentaIFRS>();
        }

        public static List<CuentaIFRS> GetAll(CuentaIFRSTipoInforme tipoInforme, Empresa empresa, Ano anio)
        {
            return
                 (
                 from query in Query.GetCuentaIFRSes(empresa, anio, tipoInforme)
                 orderby query.CodigoCuenta
                 select query
                 ).ToList<CuentaIFRS>();
        }

        public static List<CuentaIFRS> GetAll(CuentaIFRSClasificacion clasificacion, CuentaIFRSTipoInforme tipoInforme, Ano ano)
        {
            return
                 (
                 from query in Query.GetCuentaIFRSes(clasificacion, tipoInforme)
                 where query.Ano == ano
                 orderby query.Codigo
                 select query
                 ).ToList<CuentaIFRS>();
        }

        public static List<CuentaIFRS> GetAll(CuentaIFRSClasificacion clasificacion, int anoNumero)
        {
            return
                 (
                 from query in Query.GetCuentaIFRSes(clasificacion)
                 where query.AnoNumero == anoNumero
                 orderby query.CodigoCuenta
                 select query
                 ).ToList<CuentaIFRS>();
        }
    }
}