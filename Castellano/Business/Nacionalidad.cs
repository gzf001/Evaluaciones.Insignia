using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Nacionalidad
	{
		public static Nacionalidad Chilena
		{
			get
			{
				return Castellano.Nacionalidad.Get(1);
			}
		}

		public static Nacionalidad Get(Int16 codigo)
		{
			return Query.GetNacionalidades().SingleOrDefault<Nacionalidad>(x => x.Codigo == codigo);
		}

		public static List<Nacionalidad> GetAll()
		{
			return
				(
				from query in Query.GetNacionalidades()
				select query
				).ToList<Nacionalidad>();
		}
	}
}