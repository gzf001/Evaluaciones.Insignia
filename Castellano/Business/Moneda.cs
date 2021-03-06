using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class Moneda
	{
		public static Moneda Get(int tipoMonedaCodigo)
		{
			return Query.GetMonedas().SingleOrDefault<Moneda>(x => x.TipoMonedaCodigo == tipoMonedaCodigo);
		}

		public static List<Moneda> GetAll()
		{
			return
				(
				from query in Query.GetMonedas()
				select query
				).ToList<Moneda>();
		}
	}
}