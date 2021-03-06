using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class MonedaDiaria
	{
		public static MonedaDiaria Get(int tipoMonedaCodigo, DateTime calendarioFecha)
		{
			return Query.GetMonedaDiarias().SingleOrDefault<MonedaDiaria>(x => x.TipoMonedaCodigo == tipoMonedaCodigo && x.CalendarioFecha == calendarioFecha);
		}

		public static MonedaDiaria Get(TipoMoneda tipoMoneda, Calendario calendario)
		{
			return Query.GetMonedaDiarias(tipoMoneda).SingleOrDefault<MonedaDiaria>(x => x.Calendario == calendario);
		}

		public static List<MonedaDiaria> GetAll()
		{
			return
				(
				from query in Query.GetMonedaDiarias()
				orderby query.CalendarioFecha
				select query
				).ToList<MonedaDiaria>();
		}

		public static List<MonedaDiaria> GetAll(TipoMoneda tipoMoneda, AnoMes anoMes)
		{
			return
				(
				from query in Query.GetMonedaDiarias(tipoMoneda, anoMes)
				orderby query.CalendarioFecha
				select query
				).ToList<MonedaDiaria>();
		}
	}
}