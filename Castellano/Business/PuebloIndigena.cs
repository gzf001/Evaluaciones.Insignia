using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class PuebloIndigena
	{
		public static PuebloIndigena Get(Int32 codigo)
		{
			return Query.GetPuebloIndigenas().SingleOrDefault<PuebloIndigena>(x => x.Codigo == codigo);
		}

		public static List<PuebloIndigena> GetAll()
		{
			return
				(
				from query in Query.GetPuebloIndigenas()
				select query
				).ToList<PuebloIndigena>();
		}
	}
}