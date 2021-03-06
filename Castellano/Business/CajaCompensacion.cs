using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class CajaCompensacion
	{
		public static CajaCompensacion Get(Int32 codigo)
		{
			return Query.GetCajaCompensaciones().SingleOrDefault<CajaCompensacion>(x => x.Codigo == codigo);
		}

		public static List<CajaCompensacion> GetAll()
		{
			return
				(
				from query in Query.GetCajaCompensaciones()
				select query
				).ToList<CajaCompensacion>();
		}
	}
}