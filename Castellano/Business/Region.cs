using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Region
	{
		public static Region Get(Int16 codigo)
		{
			return Query.GetRegiones().SingleOrDefault<Region>(x => x.Codigo == codigo);
		}

		public static List<Region> GetAll()
		{
			return
				(
				from query in Query.GetRegiones()
				select query
				).ToList<Region>();
		}
	}
}