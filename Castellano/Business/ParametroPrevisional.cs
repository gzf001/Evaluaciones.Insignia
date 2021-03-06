using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class ParametroPrevisional
	{
		public static ParametroPrevisional Get(AnoMes anoMes)
		{
			return Query.GetParametroPrevisionales().SingleOrDefault<ParametroPrevisional>(x => x.AnoMes == anoMes);
		}

		public static ParametroPrevisional Get(Ano ano, Mes mes)
		{
			return Query.GetParametroPrevisionales().SingleOrDefault<ParametroPrevisional>(x => x.AnoMes.Ano == ano && x.AnoMes.Mes == mes);
		}

		public static ParametroPrevisional Get(int anoNumero, int mesNumero)
		{
			return Query.GetParametroPrevisionales().SingleOrDefault<ParametroPrevisional>(x => x.AnoNumero == anoNumero && x.MesNumero == mesNumero);
		}

		public static List<ParametroPrevisional> GetAll()
		{
			return
				(
				from query in Query.GetParametroPrevisionales()
				select query
				).ToList<ParametroPrevisional>();
		}
	}
}