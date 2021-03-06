using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class SituacionLaboral
	{
		public static SituacionLaboral Get(Int32 codigo)
		{
			return Query.GetSituacionLaborales().SingleOrDefault<SituacionLaboral>(x => x.Codigo == codigo);
		}

		public static List<SituacionLaboral> GetAll()
		{
			return
				(
				from query in Query.GetSituacionLaborales()
				select query
				).ToList<SituacionLaboral>();
		}
	}
}