using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class TipoAtencionMedica
	{
		public static TipoAtencionMedica Get(Int32 codigo)
		{
			return Query.GetTipoAtencionMedicas().SingleOrDefault<TipoAtencionMedica>(x => x.Codigo == codigo);
		}

		public static List<TipoAtencionMedica> GetAll()
		{
			return
				(
				from query in Query.GetTipoAtencionMedicas()
				select query
				).ToList<TipoAtencionMedica>();
		}
	}
}