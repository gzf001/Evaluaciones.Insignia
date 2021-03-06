using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class ConfiguracionContable
	{
        public static ConfiguracionContable Get(Castellano.Empresa empresa, Castellano.Ano anio)
        {
            return Query.GetConfiguracionContables(empresa).SingleOrDefault<Castellano.ConfiguracionContable>(x => x.Ano == anio);
        }

        public static List<ConfiguracionContable> GetAll()
        {
            return
                (
                from query in Query.GetConfiguracionContables()
                select query
                ).ToList<ConfiguracionContable>();
        }
	}
}