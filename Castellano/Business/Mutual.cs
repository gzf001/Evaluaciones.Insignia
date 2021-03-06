using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Mutual
	{
		public static Mutual Get(Int32 codigo)
		{
			return Query.GetMutuales().SingleOrDefault<Mutual>(x => x.Codigo == codigo);
		}

		public static List<Mutual> GetAll()
		{
			return
				(
				from query in Query.GetMutuales()
				select query
				).ToList<Mutual>();
		}
	}
}