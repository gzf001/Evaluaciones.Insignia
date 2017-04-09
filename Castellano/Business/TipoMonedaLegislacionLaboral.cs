using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoMonedaLegislacionLaboral
	{
		public static List<TipoMonedaLegislacionLaboral> GetAll()
		{
			return
				(
				from query in Query.GetTipoMonedaLegislacionLaborales()
				select query
				).ToList<TipoMonedaLegislacionLaboral>();
		}
	}
}