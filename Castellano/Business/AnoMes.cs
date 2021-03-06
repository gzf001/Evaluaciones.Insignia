using System;
using System.Collections.Generic;
using System.Linq;
namespace Castellano
{
	public partial class AnoMes
	{
		public string Nombre
		{
			get
			{
				return string.Format("{0} {1}", this.Mes.Nombre, this.AnoNumero);
			}
		}

        public static bool Exists(DateTime desde, DateTime hasta)
        {
            return Query.GetAnoMeses(desde, hasta).Any<Castellano.AnoMes>();
        }

		public static AnoMes Get(Int32 anoNumero, Int32 mesNumero)
		{
			return Query.GetAnoMeses().SingleOrDefault<AnoMes>(x => x.AnoNumero == anoNumero && x.MesNumero == mesNumero);
		}

		public static AnoMes Get(Ano ano, Mes mes)
		{
			return Query.GetAnoMeses().SingleOrDefault<AnoMes>(x => x.Ano == ano && x.Mes == mes);
		}

		public static List<AnoMes> GetAll(DateTime desde, DateTime hasta)
		{
			return
				(
				from query in Query.GetAnoMeses(desde, hasta)
				orderby query.AnoNumero, query.MesNumero
				select query
				).ToList<AnoMes>();
		}

		public static List<AnoMes> GetAll()
		{
			return
				(
				from query in Query.GetAnoMeses()
				orderby query.AnoNumero, query.MesNumero
				select query
				).ToList<AnoMes>();
		}

		public static List<AnoMes> GetAll(Ano ano)
		{
			return
				(
				from query in Query.GetAnoMeses(ano)
				orderby query.MesNumero
				select query
				).ToList<AnoMes>();
		}
    }
}