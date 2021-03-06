using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoSubministroAgua
	{
		public static TipoSubministroAgua Get(Int32 codigo)
		{
			return Query.GetTipoSubministroAguas().SingleOrDefault<TipoSubministroAgua>(x => x.Codigo == codigo);
		}

		public static List<TipoSubministroAgua> GetAll()
		{
			return
				(
				from query in Query.GetTipoSubministroAguas()
				select query
				).ToList<TipoSubministroAgua>();
		}
	}
}