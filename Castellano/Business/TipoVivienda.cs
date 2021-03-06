using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoVivienda
	{
		public static TipoVivienda Get(Int32 codigo)
		{
			return Query.GetTipoViviendas().SingleOrDefault<TipoVivienda>(x => x.Codigo == codigo);
		}

		public static List<TipoVivienda> GetAll()
		{
			return
				(
				from query in Query.GetTipoViviendas()
				select query
				).ToList<TipoVivienda>();
		}
	}
}