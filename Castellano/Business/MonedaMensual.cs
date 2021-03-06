using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class MonedaMensual
	{
		public static MonedaMensual Get(int tipoMonedaCodigo, Int32 anoNumero, Int32 mesNumero)
		{
			return Query.GetMonedaMensuales().SingleOrDefault<MonedaMensual>(x => x.TipoMonedaCodigo == tipoMonedaCodigo && x.AnoNumero == anoNumero && x.MesNumero == mesNumero);
		}

		public static List<MonedaMensual> GetAll()
		{
			return
				(
				from query in Query.GetMonedaMensuales()
				select query
				).ToList<MonedaMensual>();
		}

		public static List<MonedaMensual> GetAll(TipoMoneda tipoMoneda, Ano ano)
		{
			return
				(
				from query in Query.GetMonedaMensuales(tipoMoneda, ano)
				select query
				).ToList<MonedaMensual>();
		}

		public static MonedaMensual Get(TipoMoneda tipoMoneda, AnoMes anoMes)
		{
			return Query.GetMonedaMensuales().SingleOrDefault<MonedaMensual>(x => x.TipoMoneda == tipoMoneda && x.AnoMes == anoMes);
		}
	}
}