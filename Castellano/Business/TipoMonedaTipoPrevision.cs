using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoMonedaTipoPrevision
	{
		public static List<TipoMonedaTipoPrevision> GetAll()
		{
			return
				(
				from query in Query.GetTipoMonedaTipoPrevisiones()
				select query
				).ToList<TipoMonedaTipoPrevision>();
		}
	}
}