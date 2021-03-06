using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class AFPAnoMes
	{
		public static AFPAnoMes Get(Int32 tipoInstitucionValorSeguroCodigo, Int32 institucionValorSeguroCodigo, Int32 anoNumero, Int32 mesNumero)
		{
			return Query.GetAFPAnoMeses().SingleOrDefault<AFPAnoMes>(x => x.TipoInstitucionValorSeguroCodigo == tipoInstitucionValorSeguroCodigo && x.InstitucionValorSeguroCodigo == institucionValorSeguroCodigo && x.AnoNumero == anoNumero && x.MesNumero == mesNumero);
		}

		public static List<AFPAnoMes> GetAll()
		{
			return
				(
				from query in Query.GetAFPAnoMeses()
				select query
				).ToList<AFPAnoMes>();
		}

		public static List<AFPAnoMes> GetAll(Ano ano, Mes mes)
		{
			return
				(
				from query in Query.GetAFPAnoMeses(ano, mes)
				orderby query.InstitucionValorSeguroCodigo
				select query
				).ToList<AFPAnoMes>();
		}

		public static List<AFPAnoMes> GetAll(AnoMes anoMes)
		{
			return
				(
				from query in Query.GetAFPAnoMeses(anoMes)
				orderby query.InstitucionValorSeguroCodigo
				select query
				).ToList<AFPAnoMes>();
		}
	}
}