using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class AreaGeografica
	{
		public static AreaGeografica Get(Int32 codigo)
		{
			return Query.GetAreaGeograficas().SingleOrDefault<AreaGeografica>(x => x.Codigo == codigo);
		}

		public static List<AreaGeografica> GetAll()
		{
			return
				(
				from query in Query.GetAreaGeograficas()
				select query
				).ToList<AreaGeografica>();
		}
	}
}