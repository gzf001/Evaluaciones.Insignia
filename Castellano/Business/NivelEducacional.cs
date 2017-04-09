using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class NivelEducacional
	{
		public static NivelEducacional Get(Int32 codigo)
		{
			return Query.GetNivelEducacionales().SingleOrDefault<NivelEducacional>(x => x.Codigo == codigo);
		}

		public static List<NivelEducacional> GetAll()
		{
			return
				(
				from query in Query.GetNivelEducacionales()
				select query
				).ToList<NivelEducacional>();
		}
	}
}