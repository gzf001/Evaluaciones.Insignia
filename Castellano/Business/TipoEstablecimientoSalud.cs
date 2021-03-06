using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoEstablecimientoSalud
	{
		public static List<TipoEstablecimientoSalud> GetAll()
		{
			return
				(
				from query in Query.GetTipoEstablecimientoSaludes()
                orderby query.Codigo
				select query
				).ToList<TipoEstablecimientoSalud>();
		}
	}
}